//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Substrate.NetApi.Model.Types.Base;
using System.Collections.Generic;


namespace Substrate.NetApi.Generated.Model.pallet_election_provider_multi_phase.pallet
{
    
    
    public enum Call
    {
        
        submit_unsigned = 0,
        
        set_minimum_untrusted_score = 1,
        
        set_emergency_election_result = 2,
        
        submit = 3,
        
        governance_fallback = 4,
    }
    
    /// <summary>
    /// >> 310 - Variant[pallet_election_provider_multi_phase.pallet.Call]
    /// Contains one variant per dispatchable that can be called by an extrinsic.
    /// </summary>
    public sealed class EnumCall : BaseEnumExt<Call, BaseTuple<Substrate.NetApi.Generated.Model.pallet_election_provider_multi_phase.RawSolution, Substrate.NetApi.Generated.Model.pallet_election_provider_multi_phase.SolutionOrSnapshotSize>, Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Generated.Model.sp_npos_elections.ElectionScore>, Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Generated.Model.sp_npos_elections.Support>>, Substrate.NetApi.Generated.Model.pallet_election_provider_multi_phase.RawSolution, BaseTuple<Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Primitive.U32>, Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Primitive.U32>>>
    {
    }
}