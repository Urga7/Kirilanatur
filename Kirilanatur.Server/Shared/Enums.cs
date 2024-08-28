namespace Kirilanatur.Server.Shared {

    public enum PaymentMethodOption {
        Visa = 0,
        BankTransfer = 1,
    }

    public enum ShippingMethodOption {
        StandardShipping = 0,
        ExpressShipping = 1,   
        ParcelLockerGsl = 2,   
        InStorePickup = 3,
    }

    public enum OrderStatusType {
        InReservation = 0,
        Processing = 1,
        Completed = 2,
        Cancelled = 3,
    }

}
