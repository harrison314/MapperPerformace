﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MapperPerformace.Ef
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class AdventureWorks2014Entities : DbContext
    {
        public AdventureWorks2014Entities()
            : base("name=AdventureWorks2014Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AWBuildVersion> AWBuildVersions { get; set; }
        public virtual DbSet<DatabaseLog> DatabaseLogs { get; set; }
        public virtual DbSet<ErrorLog> ErrorLogs { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeDepartmentHistory> EmployeeDepartmentHistories { get; set; }
        public virtual DbSet<EmployeePayHistory> EmployeePayHistories { get; set; }
        public virtual DbSet<JobCandidate> JobCandidates { get; set; }
        public virtual DbSet<Shift> Shifts { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<AddressType> AddressTypes { get; set; }
        public virtual DbSet<BusinessEntity> BusinessEntities { get; set; }
        public virtual DbSet<BusinessEntityAddress> BusinessEntityAddresses { get; set; }
        public virtual DbSet<BusinessEntityContact> BusinessEntityContacts { get; set; }
        public virtual DbSet<ContactType> ContactTypes { get; set; }
        public virtual DbSet<CountryRegion> CountryRegions { get; set; }
        public virtual DbSet<EmailAddress> EmailAddresses { get; set; }
        public virtual DbSet<Password> Passwords { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<PersonPhone> PersonPhones { get; set; }
        public virtual DbSet<PhoneNumberType> PhoneNumberTypes { get; set; }
        public virtual DbSet<StateProvince> StateProvinces { get; set; }
        public virtual DbSet<BillOfMaterial> BillOfMaterials { get; set; }
        public virtual DbSet<Culture> Cultures { get; set; }
        public virtual DbSet<Illustration> Illustrations { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<ProductCostHistory> ProductCostHistories { get; set; }
        public virtual DbSet<ProductDescription> ProductDescriptions { get; set; }
        public virtual DbSet<ProductInventory> ProductInventories { get; set; }
        public virtual DbSet<ProductListPriceHistory> ProductListPriceHistories { get; set; }
        public virtual DbSet<ProductModel> ProductModels { get; set; }
        public virtual DbSet<ProductModelIllustration> ProductModelIllustrations { get; set; }
        public virtual DbSet<ProductModelProductDescriptionCulture> ProductModelProductDescriptionCultures { get; set; }
        public virtual DbSet<ProductPhoto> ProductPhotoes { get; set; }
        public virtual DbSet<ProductProductPhoto> ProductProductPhotoes { get; set; }
        public virtual DbSet<ProductReview> ProductReviews { get; set; }
        public virtual DbSet<ProductSubcategory> ProductSubcategories { get; set; }
        public virtual DbSet<ScrapReason> ScrapReasons { get; set; }
        public virtual DbSet<TransactionHistory> TransactionHistories { get; set; }
        public virtual DbSet<TransactionHistoryArchive> TransactionHistoryArchives { get; set; }
        public virtual DbSet<UnitMeasure> UnitMeasures { get; set; }
        public virtual DbSet<WorkOrder> WorkOrders { get; set; }
        public virtual DbSet<WorkOrderRouting> WorkOrderRoutings { get; set; }
        public virtual DbSet<ProductVendor> ProductVendors { get; set; }
        public virtual DbSet<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
        public virtual DbSet<PurchaseOrderHeader> PurchaseOrderHeaders { get; set; }
        public virtual DbSet<ShipMethod> ShipMethods { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }
        public virtual DbSet<CountryRegionCurrency> CountryRegionCurrencies { get; set; }
        public virtual DbSet<CreditCard> CreditCards { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<CurrencyRate> CurrencyRates { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<PersonCreditCard> PersonCreditCards { get; set; }
        public virtual DbSet<SalesOrderDetail> SalesOrderDetails { get; set; }
        public virtual DbSet<SalesOrderHeader> SalesOrderHeaders { get; set; }
        public virtual DbSet<SalesOrderHeaderSalesReason> SalesOrderHeaderSalesReasons { get; set; }
        public virtual DbSet<SalesPerson> SalesPersons { get; set; }
        public virtual DbSet<SalesPersonQuotaHistory> SalesPersonQuotaHistories { get; set; }
        public virtual DbSet<SalesReason> SalesReasons { get; set; }
        public virtual DbSet<SalesTaxRate> SalesTaxRates { get; set; }
        public virtual DbSet<SalesTerritory> SalesTerritories { get; set; }
        public virtual DbSet<SalesTerritoryHistory> SalesTerritoryHistories { get; set; }
        public virtual DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public virtual DbSet<SpecialOffer> SpecialOffers { get; set; }
        public virtual DbSet<SpecialOfferProduct> SpecialOfferProducts { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<ProductDocument> ProductDocuments { get; set; }
        public virtual DbSet<vEmployee> vEmployees { get; set; }
        public virtual DbSet<vEmployeeDepartment> vEmployeeDepartments { get; set; }
        public virtual DbSet<vEmployeeDepartmentHistory> vEmployeeDepartmentHistories { get; set; }
        public virtual DbSet<vJobCandidate> vJobCandidates { get; set; }
        public virtual DbSet<vJobCandidateEducation> vJobCandidateEducations { get; set; }
        public virtual DbSet<vJobCandidateEmployment> vJobCandidateEmployments { get; set; }
        public virtual DbSet<vAdditionalContactInfo> vAdditionalContactInfoes { get; set; }
        public virtual DbSet<vStateProvinceCountryRegion> vStateProvinceCountryRegions { get; set; }
        public virtual DbSet<vProductAndDescription> vProductAndDescriptions { get; set; }
        public virtual DbSet<vProductModelCatalogDescription> vProductModelCatalogDescriptions { get; set; }
        public virtual DbSet<vProductModelInstruction> vProductModelInstructions { get; set; }
        public virtual DbSet<vVendorWithAddress> vVendorWithAddresses { get; set; }
        public virtual DbSet<vVendorWithContact> vVendorWithContacts { get; set; }
        public virtual DbSet<vIndividualCustomer> vIndividualCustomers { get; set; }
        public virtual DbSet<vPersonDemographic> vPersonDemographics { get; set; }
        public virtual DbSet<vSalesPerson> vSalesPersons { get; set; }
        public virtual DbSet<vSalesPersonSalesByFiscalYear> vSalesPersonSalesByFiscalYears { get; set; }
        public virtual DbSet<vStoreWithAddress> vStoreWithAddresses { get; set; }
        public virtual DbSet<vStoreWithContact> vStoreWithContacts { get; set; }
        public virtual DbSet<vStoreWithDemographic> vStoreWithDemographics { get; set; }
    
        [DbFunction("AdventureWorks2014Entities", "ufnGetContactInformation")]
        public virtual IQueryable<ufnGetContactInformation_Result> ufnGetContactInformation(Nullable<int> personID)
        {
            var personIDParameter = personID.HasValue ?
                new ObjectParameter("PersonID", personID) :
                new ObjectParameter("PersonID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<ufnGetContactInformation_Result>("[AdventureWorks2014Entities].[ufnGetContactInformation](@PersonID)", personIDParameter);
        }
    
        public virtual ObjectResult<HrStats_Result> HrStats(string pGender, Nullable<int> top)
        {
            var pGenderParameter = pGender != null ?
                new ObjectParameter("pGender", pGender) :
                new ObjectParameter("pGender", typeof(string));
    
            var topParameter = top.HasValue ?
                new ObjectParameter("top", top) :
                new ObjectParameter("top", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<HrStats_Result>("HrStats", pGenderParameter, topParameter);
        }
    
        public virtual ObjectResult<uspGetBillOfMaterials_Result> uspGetBillOfMaterials(Nullable<int> startProductID, Nullable<System.DateTime> checkDate)
        {
            var startProductIDParameter = startProductID.HasValue ?
                new ObjectParameter("StartProductID", startProductID) :
                new ObjectParameter("StartProductID", typeof(int));
    
            var checkDateParameter = checkDate.HasValue ?
                new ObjectParameter("CheckDate", checkDate) :
                new ObjectParameter("CheckDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<uspGetBillOfMaterials_Result>("uspGetBillOfMaterials", startProductIDParameter, checkDateParameter);
        }
    
        public virtual ObjectResult<uspGetEmployeeManagers_Result> uspGetEmployeeManagers(Nullable<int> businessEntityID)
        {
            var businessEntityIDParameter = businessEntityID.HasValue ?
                new ObjectParameter("BusinessEntityID", businessEntityID) :
                new ObjectParameter("BusinessEntityID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<uspGetEmployeeManagers_Result>("uspGetEmployeeManagers", businessEntityIDParameter);
        }
    
        public virtual ObjectResult<uspGetManagerEmployees_Result> uspGetManagerEmployees(Nullable<int> businessEntityID)
        {
            var businessEntityIDParameter = businessEntityID.HasValue ?
                new ObjectParameter("BusinessEntityID", businessEntityID) :
                new ObjectParameter("BusinessEntityID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<uspGetManagerEmployees_Result>("uspGetManagerEmployees", businessEntityIDParameter);
        }
    
        public virtual ObjectResult<uspGetWhereUsedProductID_Result> uspGetWhereUsedProductID(Nullable<int> startProductID, Nullable<System.DateTime> checkDate)
        {
            var startProductIDParameter = startProductID.HasValue ?
                new ObjectParameter("StartProductID", startProductID) :
                new ObjectParameter("StartProductID", typeof(int));
    
            var checkDateParameter = checkDate.HasValue ?
                new ObjectParameter("CheckDate", checkDate) :
                new ObjectParameter("CheckDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<uspGetWhereUsedProductID_Result>("uspGetWhereUsedProductID", startProductIDParameter, checkDateParameter);
        }
    
        public virtual int uspLogError(ObjectParameter errorLogID)
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspLogError", errorLogID);
        }
    
        public virtual int uspPrintError()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspPrintError");
        }
    
        public virtual int uspSearchCandidateResumes(string searchString, Nullable<bool> useInflectional, Nullable<bool> useThesaurus, Nullable<int> language)
        {
            var searchStringParameter = searchString != null ?
                new ObjectParameter("searchString", searchString) :
                new ObjectParameter("searchString", typeof(string));
    
            var useInflectionalParameter = useInflectional.HasValue ?
                new ObjectParameter("useInflectional", useInflectional) :
                new ObjectParameter("useInflectional", typeof(bool));
    
            var useThesaurusParameter = useThesaurus.HasValue ?
                new ObjectParameter("useThesaurus", useThesaurus) :
                new ObjectParameter("useThesaurus", typeof(bool));
    
            var languageParameter = language.HasValue ?
                new ObjectParameter("language", language) :
                new ObjectParameter("language", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspSearchCandidateResumes", searchStringParameter, useInflectionalParameter, useThesaurusParameter, languageParameter);
        }
    
        public virtual int uspUpdateEmployeeHireInfo(Nullable<int> businessEntityID, string jobTitle, Nullable<System.DateTime> hireDate, Nullable<System.DateTime> rateChangeDate, Nullable<decimal> rate, Nullable<byte> payFrequency, Nullable<bool> currentFlag)
        {
            var businessEntityIDParameter = businessEntityID.HasValue ?
                new ObjectParameter("BusinessEntityID", businessEntityID) :
                new ObjectParameter("BusinessEntityID", typeof(int));
    
            var jobTitleParameter = jobTitle != null ?
                new ObjectParameter("JobTitle", jobTitle) :
                new ObjectParameter("JobTitle", typeof(string));
    
            var hireDateParameter = hireDate.HasValue ?
                new ObjectParameter("HireDate", hireDate) :
                new ObjectParameter("HireDate", typeof(System.DateTime));
    
            var rateChangeDateParameter = rateChangeDate.HasValue ?
                new ObjectParameter("RateChangeDate", rateChangeDate) :
                new ObjectParameter("RateChangeDate", typeof(System.DateTime));
    
            var rateParameter = rate.HasValue ?
                new ObjectParameter("Rate", rate) :
                new ObjectParameter("Rate", typeof(decimal));
    
            var payFrequencyParameter = payFrequency.HasValue ?
                new ObjectParameter("PayFrequency", payFrequency) :
                new ObjectParameter("PayFrequency", typeof(byte));
    
            var currentFlagParameter = currentFlag.HasValue ?
                new ObjectParameter("CurrentFlag", currentFlag) :
                new ObjectParameter("CurrentFlag", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspUpdateEmployeeHireInfo", businessEntityIDParameter, jobTitleParameter, hireDateParameter, rateChangeDateParameter, rateParameter, payFrequencyParameter, currentFlagParameter);
        }
    
        public virtual int uspUpdateEmployeeLogin(Nullable<int> businessEntityID, string loginID, string jobTitle, Nullable<System.DateTime> hireDate, Nullable<bool> currentFlag)
        {
            var businessEntityIDParameter = businessEntityID.HasValue ?
                new ObjectParameter("BusinessEntityID", businessEntityID) :
                new ObjectParameter("BusinessEntityID", typeof(int));
    
            var loginIDParameter = loginID != null ?
                new ObjectParameter("LoginID", loginID) :
                new ObjectParameter("LoginID", typeof(string));
    
            var jobTitleParameter = jobTitle != null ?
                new ObjectParameter("JobTitle", jobTitle) :
                new ObjectParameter("JobTitle", typeof(string));
    
            var hireDateParameter = hireDate.HasValue ?
                new ObjectParameter("HireDate", hireDate) :
                new ObjectParameter("HireDate", typeof(System.DateTime));
    
            var currentFlagParameter = currentFlag.HasValue ?
                new ObjectParameter("CurrentFlag", currentFlag) :
                new ObjectParameter("CurrentFlag", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspUpdateEmployeeLogin", businessEntityIDParameter, loginIDParameter, jobTitleParameter, hireDateParameter, currentFlagParameter);
        }
    
        public virtual int uspUpdateEmployeePersonalInfo(Nullable<int> businessEntityID, string nationalIDNumber, Nullable<System.DateTime> birthDate, string maritalStatus, string gender)
        {
            var businessEntityIDParameter = businessEntityID.HasValue ?
                new ObjectParameter("BusinessEntityID", businessEntityID) :
                new ObjectParameter("BusinessEntityID", typeof(int));
    
            var nationalIDNumberParameter = nationalIDNumber != null ?
                new ObjectParameter("NationalIDNumber", nationalIDNumber) :
                new ObjectParameter("NationalIDNumber", typeof(string));
    
            var birthDateParameter = birthDate.HasValue ?
                new ObjectParameter("BirthDate", birthDate) :
                new ObjectParameter("BirthDate", typeof(System.DateTime));
    
            var maritalStatusParameter = maritalStatus != null ?
                new ObjectParameter("MaritalStatus", maritalStatus) :
                new ObjectParameter("MaritalStatus", typeof(string));
    
            var genderParameter = gender != null ?
                new ObjectParameter("Gender", gender) :
                new ObjectParameter("Gender", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspUpdateEmployeePersonalInfo", businessEntityIDParameter, nationalIDNumberParameter, birthDateParameter, maritalStatusParameter, genderParameter);
        }
    }
}
