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


namespace Bifrost.NetApi.Generated.Model.bifrost_slp.pallet
{
    
    
    /// <summary>
    /// >> Error
    /// The `Error` enum of this pallet.
    /// </summary>
    public enum Error
    {
        
        /// <summary>
        /// >> OperateOriginNotSet
        /// </summary>
        OperateOriginNotSet = 0,
        
        /// <summary>
        /// >> NotAuthorized
        /// </summary>
        NotAuthorized = 1,
        
        /// <summary>
        /// >> NotSupportedCurrencyId
        /// </summary>
        NotSupportedCurrencyId = 2,
        
        /// <summary>
        /// >> FailToAddDelegator
        /// </summary>
        FailToAddDelegator = 3,
        
        /// <summary>
        /// >> OverFlow
        /// </summary>
        OverFlow = 4,
        
        /// <summary>
        /// >> UnderFlow
        /// </summary>
        UnderFlow = 5,
        
        /// <summary>
        /// >> NotExist
        /// </summary>
        NotExist = 6,
        
        /// <summary>
        /// >> LowerThanMinimum
        /// </summary>
        LowerThanMinimum = 7,
        
        /// <summary>
        /// >> GreaterThanMaximum
        /// </summary>
        GreaterThanMaximum = 8,
        
        /// <summary>
        /// >> AlreadyBonded
        /// </summary>
        AlreadyBonded = 9,
        
        /// <summary>
        /// >> AccountNotExist
        /// </summary>
        AccountNotExist = 10,
        
        /// <summary>
        /// >> DelegatorNotExist
        /// </summary>
        DelegatorNotExist = 11,
        
        /// <summary>
        /// >> XcmFailure
        /// </summary>
        XcmFailure = 12,
        
        /// <summary>
        /// >> DelegatorNotBonded
        /// </summary>
        DelegatorNotBonded = 13,
        
        /// <summary>
        /// >> ExceedActiveMaximum
        /// </summary>
        ExceedActiveMaximum = 14,
        
        /// <summary>
        /// >> ProblematicLedger
        /// </summary>
        ProblematicLedger = 15,
        
        /// <summary>
        /// >> NotEnoughToUnbond
        /// </summary>
        NotEnoughToUnbond = 16,
        
        /// <summary>
        /// >> ExceedUnlockingRecords
        /// </summary>
        ExceedUnlockingRecords = 17,
        
        /// <summary>
        /// >> RebondExceedUnlockingAmount
        /// </summary>
        RebondExceedUnlockingAmount = 18,
        
        /// <summary>
        /// >> DecodingError
        /// </summary>
        DecodingError = 19,
        
        /// <summary>
        /// >> EncodingError
        /// </summary>
        EncodingError = 20,
        
        /// <summary>
        /// >> VectorEmpty
        /// </summary>
        VectorEmpty = 21,
        
        /// <summary>
        /// >> ValidatorSetNotExist
        /// </summary>
        ValidatorSetNotExist = 22,
        
        /// <summary>
        /// >> ValidatorNotExist
        /// </summary>
        ValidatorNotExist = 23,
        
        /// <summary>
        /// >> InvalidTimeUnit
        /// </summary>
        InvalidTimeUnit = 24,
        
        /// <summary>
        /// >> AmountZero
        /// </summary>
        AmountZero = 25,
        
        /// <summary>
        /// >> AmountNotZero
        /// </summary>
        AmountNotZero = 26,
        
        /// <summary>
        /// >> AlreadyExist
        /// </summary>
        AlreadyExist = 27,
        
        /// <summary>
        /// >> ValidatorStillInUse
        /// </summary>
        ValidatorStillInUse = 28,
        
        /// <summary>
        /// >> TimeUnitNotExist
        /// </summary>
        TimeUnitNotExist = 29,
        
        /// <summary>
        /// >> FeeSourceNotExist
        /// </summary>
        FeeSourceNotExist = 30,
        
        /// <summary>
        /// >> WeightAndFeeNotExists
        /// </summary>
        WeightAndFeeNotExists = 31,
        
        /// <summary>
        /// >> MinimumsAndMaximumsNotExist
        /// </summary>
        MinimumsAndMaximumsNotExist = 32,
        
        /// <summary>
        /// >> QueryNotExist
        /// </summary>
        QueryNotExist = 33,
        
        /// <summary>
        /// >> DelaysNotExist
        /// </summary>
        DelaysNotExist = 34,
        
        /// <summary>
        /// >> Unexpected
        /// </summary>
        Unexpected = 35,
        
        /// <summary>
        /// >> QueryResponseRemoveError
        /// </summary>
        QueryResponseRemoveError = 36,
        
        /// <summary>
        /// >> InvalidHostingFee
        /// </summary>
        InvalidHostingFee = 37,
        
        /// <summary>
        /// >> InvalidAccount
        /// </summary>
        InvalidAccount = 38,
        
        /// <summary>
        /// >> IncreaseTokenPoolError
        /// </summary>
        IncreaseTokenPoolError = 39,
        
        /// <summary>
        /// >> TuneExchangeRateLimitNotSet
        /// </summary>
        TuneExchangeRateLimitNotSet = 40,
        
        /// <summary>
        /// >> CurrencyLatestTuneRecordNotExist
        /// </summary>
        CurrencyLatestTuneRecordNotExist = 41,
        
        /// <summary>
        /// >> InvalidTransferSource
        /// </summary>
        InvalidTransferSource = 42,
        
        /// <summary>
        /// >> ValidatorNotProvided
        /// </summary>
        ValidatorNotProvided = 43,
        
        /// <summary>
        /// >> Unsupported
        /// </summary>
        Unsupported = 44,
        
        /// <summary>
        /// >> ValidatorNotBonded
        /// </summary>
        ValidatorNotBonded = 45,
        
        /// <summary>
        /// >> AlreadyRequested
        /// </summary>
        AlreadyRequested = 46,
        
        /// <summary>
        /// >> RequestNotExist
        /// </summary>
        RequestNotExist = 47,
        
        /// <summary>
        /// >> AlreadyLeaving
        /// </summary>
        AlreadyLeaving = 48,
        
        /// <summary>
        /// >> DelegatorNotLeaving
        /// </summary>
        DelegatorNotLeaving = 49,
        
        /// <summary>
        /// >> RequestNotDue
        /// </summary>
        RequestNotDue = 50,
        
        /// <summary>
        /// >> LeavingNotDue
        /// </summary>
        LeavingNotDue = 51,
        
        /// <summary>
        /// >> DelegatorSetNotExist
        /// </summary>
        DelegatorSetNotExist = 52,
        
        /// <summary>
        /// >> DelegatorLeaving
        /// </summary>
        DelegatorLeaving = 53,
        
        /// <summary>
        /// >> DelegatorAlreadyLeaving
        /// </summary>
        DelegatorAlreadyLeaving = 54,
        
        /// <summary>
        /// >> ValidatorError
        /// </summary>
        ValidatorError = 55,
        
        /// <summary>
        /// >> AmountNone
        /// </summary>
        AmountNone = 56,
        
        /// <summary>
        /// >> InvalidDelays
        /// </summary>
        InvalidDelays = 57,
        
        /// <summary>
        /// >> OngoingTimeUnitUpdateIntervalNotExist
        /// </summary>
        OngoingTimeUnitUpdateIntervalNotExist = 58,
        
        /// <summary>
        /// >> LastTimeUpdatedOngoingTimeUnitNotExist
        /// </summary>
        LastTimeUpdatedOngoingTimeUnitNotExist = 59,
        
        /// <summary>
        /// >> TooFrequent
        /// </summary>
        TooFrequent = 60,
        
        /// <summary>
        /// >> DestAccountNotValid
        /// </summary>
        DestAccountNotValid = 61,
        
        /// <summary>
        /// >> WhiteListNotExist
        /// </summary>
        WhiteListNotExist = 62,
        
        /// <summary>
        /// >> DelegatorAlreadyTuned
        /// </summary>
        DelegatorAlreadyTuned = 63,
        
        /// <summary>
        /// >> FeeTooHigh
        /// </summary>
        FeeTooHigh = 64,
        
        /// <summary>
        /// >> NotEnoughBalance
        /// </summary>
        NotEnoughBalance = 65,
        
        /// <summary>
        /// >> VectorTooLong
        /// </summary>
        VectorTooLong = 66,
        
        /// <summary>
        /// >> MultiCurrencyError
        /// </summary>
        MultiCurrencyError = 67,
        
        /// <summary>
        /// >> NotDelegateValidator
        /// </summary>
        NotDelegateValidator = 68,
        
        /// <summary>
        /// >> DividedByZero
        /// </summary>
        DividedByZero = 69,
        
        /// <summary>
        /// >> SharePriceNotValid
        /// </summary>
        SharePriceNotValid = 70,
        
        /// <summary>
        /// >> InvalidAmount
        /// </summary>
        InvalidAmount = 71,
        
        /// <summary>
        /// >> ValidatorMultilocationNotvalid
        /// </summary>
        ValidatorMultilocationNotvalid = 72,
        
        /// <summary>
        /// >> AmountNotProvided
        /// </summary>
        AmountNotProvided = 73,
        
        /// <summary>
        /// >> FailToConvert
        /// </summary>
        FailToConvert = 74,
        
        /// <summary>
        /// >> ExceedMaxLengthLimit
        /// </summary>
        ExceedMaxLengthLimit = 75,
        
        /// <summary>
        /// >> TransferToError
        /// Transfer to failed
        /// </summary>
        TransferToError = 76,
        
        /// <summary>
        /// >> StablePoolNotFound
        /// </summary>
        StablePoolNotFound = 77,
        
        /// <summary>
        /// >> StablePoolTokenIndexNotFound
        /// </summary>
        StablePoolTokenIndexNotFound = 78,
        
        /// <summary>
        /// >> ExceedLimit
        /// </summary>
        ExceedLimit = 79,
        
        /// <summary>
        /// >> InvalidPageNumber
        /// </summary>
        InvalidPageNumber = 80,
        
        /// <summary>
        /// >> NoMoreValidatorBoostListForCurrency
        /// </summary>
        NoMoreValidatorBoostListForCurrency = 81,
    }
    
    /// <summary>
    /// >> 800 - Variant[bifrost_slp.pallet.Error]
    /// The `Error` enum of this pallet.
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}