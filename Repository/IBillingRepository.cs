namespace Repository
{
    public interface IBillingRepository
    {
        IPatientRepository Patient { get; }
        IMemoRepository Memo { get; }

        IAtollRepository Atoll { get; }

        IIslandRepository Island { get; }

        IDoctorRepository Doctor { get; }

        IServiceRepository Service { get; }

        IAccountRepository Account { get; }

        ICountryRepository Country { get; }

        IAccountServicePrice AccountServicePrice { get; }

        ICollectionSiteRepository CollectionSite { get; }

        IInvoiceRepository Invoices { get; }


        IUserRepository Users { get; }

        IRoleRepostitory Roles { get; }

        IAthorizeDetailRepository AthorizeDetails { get; }

        ISampleRegisterRepository SampleRegisterRepository { get; }

        IUsernameAndHashRepository UsernameAndHash { get; }
    }
}
