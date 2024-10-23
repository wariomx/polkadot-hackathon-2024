#![cfg_attr(not(feature = "std"), no_std, no_main)]

#[ink::contract]
mod liquid_staking_token
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////"dataImports"//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    use ink::prelude::string::String;
    use ink::storage::Mapping;



    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////"runtimeCall"//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // Object describing the runtime call.
    #[ink::scale_derive(Encode)]
    pub enum RuntimeCall 
    {
        /// This index can be found by investigating runtime configuration. You can check the pallet
        /// order inside `construct_runtime!` block and read the position of your pallet (0-based).
        ///
        ///
        /// [See here for more.](https://substrate.stackexchange.com/questions/778/how-to-get-pallet-index-u8-of-a-pallet-in-runtime)
        #[codec(index = 8)]
        Staking(StakingCall),
    }

    // Object describing the call to the `FakeStaking` pallet.
    #[ink::scale_derive(Encode)]
    pub enum StakingCall 
    {
        // This index can be found by investigating the pallet dispatchable API. In your pallet code,
        // look for `#[pallet::call]` section and check `#[pallet::call_index(x)]` attribute of the
        // call. If these attributes are missing, use source-code order (0-based).
        #[codec(index = 0)]
        Bond 
        {
            value: Balance,
            payee: AccountId,
        },
        #[codec(index = 1)]
        BondExtra 
        {
            max_additional: Balance,
        }
    }



    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////"inkStorageVariablesStruct"////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    #[ink(storage)]
    pub struct LiquidStakingToken 
    {
        threshold_reached: bool,

        staked: Mapping<AccountId, u128>,
        balances: Mapping<AccountId, u128>,
        allowances: Mapping<(AccountId, AccountId), u128>,
        
        decimals: u128,
        name: String,
        symbol: String,
    }



    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////"inkFunctionMessages"//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    impl LiquidStakingToken 
    {
        ////////////////////////////////////////////////////////////////////////////
        /////"CONSTRUCTORS"/////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////
        #[ink(constructor)]
        pub fn new(param_name: String, param_symbol: String) -> Self 
        {
            let empty_mapping = Mapping::default();
            let empty_mapping_2 = Mapping::default();
            let empty_mapping_3 = Mapping::default();
            let _decimals = 12;

            Self {staked: empty_mapping, threshold_reached: false, balances: empty_mapping_2, allowances: empty_mapping_3, decimals: _decimals, name: param_name, symbol: param_symbol}
        }

        ////////////////////////////////////////////////////////////////////////////
        /////"FUNCTIONS"////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////
        #[ink(message, payable, selector = 1)]
        pub fn initialize_staking(&mut self)
        {
            let transferred_balance = self.env().transferred_value();
            let contract_address = self.env().account_id();
            
            assert!(transferred_balance == 100, "Transfered value does not fulfill threshold.");

            self.env()
            .call_runtime(&RuntimeCall::Staking(StakingCall::Bond {value: transferred_balance, payee: contract_address,}))
            .expect("Failed to call FakeStaking::StakeMore");

            self.threshold_reached = true;
        }

        #[ink(message, payable, selector = 2)]
        pub fn stake(&mut self) -> u128
        {
            /*
                Deposits the transferred balance into the contract.
                
                1. If the accumulated balance is now greater than or equal to `THRESHOLD`, then the
                contract will call the `FakeStaking` pallet to stake the accumulated balance.
                2. If the accumulated balance is greater than or equal to `THRESHOLD` and the contract
                is already staking, then the contract will call the `FakeStaking` pallet to increase the
                stake by the transferred balance.
                3. If the accumulated balance is less than `THRESHOLD`, then the contract will just
                accumulate the transferred balance.
                #[ink(message, payable, selector = 1)]
            */

            let caller: AccountId = self.env().caller();
            let transferred_balance = self.env().transferred_value();

            if self.threshold_reached
            {
                self.env()
                .call_runtime(&RuntimeCall::Staking(StakingCall::BondExtra {max_additional: transferred_balance,}))
                .expect("Failed to call FakeStaking::Stake");
            }

            let mut actual_staked_caller_balance = self.staked.get(caller).unwrap_or(0);
            actual_staked_caller_balance += transferred_balance;

            self.staked.insert(&caller, &actual_staked_caller_balance);

            transferred_balance
        }

        #[ink(message, payable)]
        pub fn mint_liquid_token(&mut self) -> u128
        {
            let caller = self.env().caller();
            let balance_to_mint = self.stake();

            let mut actual_address_to_mint_balance = self.balances.get(caller).unwrap_or(0);
            actual_address_to_mint_balance += balance_to_mint;

            self.balances.insert(&caller, &actual_address_to_mint_balance);

            balance_to_mint
        }

        #[ink(message)]
        pub fn transfer(&mut self, param_quantity: u128, param_address_to: AccountId)
        {
            let caller = self.env().caller();

            let mut actual_transferer_balance = self.balances.get(&caller).unwrap_or(0);

            assert!(actual_transferer_balance >= param_quantity, "Not enough funds.");

            actual_transferer_balance -= param_quantity;
            self.balances.insert(&caller, &actual_transferer_balance);

            let mut actual_to_balance = self.balances.get(param_address_to).unwrap_or(0);
            actual_to_balance += param_quantity;
            self.balances.insert(&param_address_to, &actual_to_balance);
        }

        #[ink(message)]
        pub fn set_allowance(&mut self, param_quantity: u128, param_spender: AccountId)
        {
            let caller = self.env().caller();
            let actual_caller_balance = self.balances.get(&caller).unwrap_or(0);

            assert!(actual_caller_balance >= param_quantity, "Not enough funds.");

            self.allowances.insert((caller, param_spender), &param_quantity);
        }

        #[ink(message)]
        pub fn transfer_from(&mut self, param_from: AccountId, param_quantity: u128, param_address_to: AccountId)
        {
            let caller = self.env().caller();
            let mut actual_from_balance = self.balances.get(&param_from).unwrap_or(0);
            let mut caller_allowance = self.allowance(param_from, caller);

            assert!(actual_from_balance >= param_quantity, "Not enough funds.");
            assert!(caller_allowance >= param_quantity, "Not enough allowance.");

            actual_from_balance -= param_quantity;
            caller_allowance -= param_quantity;
            self.balances.insert(&param_from, &actual_from_balance);            
            self.allowances.insert((param_from, caller), &caller_allowance);

            let mut actual_to_balance = self.balances.get(param_address_to).unwrap_or(0);
            actual_to_balance += param_quantity;
            self.balances.insert(&param_address_to, &actual_to_balance);
        }

        #[ink(message)]
        pub fn balance_of(&self, param_address_to_check: AccountId) -> u128
        {
            self.balances.get(param_address_to_check).unwrap_or(0)
        }

        #[ink(message)]
        pub fn allowance(&self, param_owner: AccountId, param_spender: AccountId) -> u128 
        {
            self.allowances.get((param_owner, param_spender)).unwrap_or_default()
        }

        #[ink(message)]
        pub fn user_staked_balance(&self, param_address_to_check: AccountId) -> u128
        {
            self.staked.get(param_address_to_check).unwrap_or(0)
        }

        #[ink(message)]
        pub fn get_name(&self) -> String
        {
            self.name.clone()
        }

        #[ink(message)]
        pub fn get_symbol(&self) -> String
        {
            self.symbol.clone()
        }

        #[ink(message)]
        pub fn get_decimals(&self) -> u128
        {
            self.decimals
        }

        #[ink(message)]
        pub fn get_contract_address(&self) -> AccountId
        {
            self.env().account_id()
        }
    }
}