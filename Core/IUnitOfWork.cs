using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core
{
    public interface IUnitOfWork
    {
        public IAboutComponentRepository AboutComponent { get; }
        public IAboutPhotoRepository AboutPhoto { get; }
        public IAdminRepository Admin { get; }
        public ICareerComponentRepository CareerComponent { get; }
        public ICareerAppContentRepository CareerAppContent { get; }
        public ICareerFormComponentRepository CareerFormComponent { get; }
        public IConfigurationRepository Configuration { get; }
        public IContactComponentRepository ContactComponent { get; }
        public IContactMessageRepository ContactMessage { get; }
        public IContentAccessComponentRepository ContentAccessComponent { get; }
        public ICountryRepository Country { get; }
        public IEthicsComponentRepository EthicsComponent { get; }
        public IEthicsFileComponentRepository EthicsFileComponent { get; }
        public IEthicsHotlineFormComponentRepository EthicsHotlineFormComponent { get; }
        public IFooterPartnerRepository FooterPartner { get; }
        public IGalleryComponentPhotoRepository GalleryComponentPhoto { get; }
        public IGalleryComponentRepository GalleryComponent { get; }
        public IGeneralApplyFileRepository GeneralApplyFile { get; }
        public IGeneralApplyRepository GeneralApply { get; }
        public IGovernanceComponentRepository GovernanceComponent { get; }
        public ILicenceRepository Licence { get; }
        public IManagementRepository Management { get; }
        public INavComponentRepository NavComponent { get; }
        public INavSubComponentRepository NavSubComponent { get; }
        public INavTitleComponentRepository NavTitleComponent { get; }
        public INewsRepository News { get; }
        public INoticeComponentRepository NoticeComponent { get; }
        public IOpportunityApplyFileRepository OpportunityApplyFile { get; }
        public IOpportunityApplyRepository OpportunityApply { get; }
        public IOpportunityRepository Opportunity { get; }
        public IPageAccessComponentRepository PageAccessComponent { get; }
        public IPageMainPhotoRepository PageMainPhoto { get; }
        public IPartnerComponentRepository PartnerComponent { get; }
        public IPartnerRepository Partner { get; }
        public IPrivacyComponentRepository PrivacyComponent { get; }
        public IProjectPhotoRepository ProjectPhoto { get; }
        public IProjectRepository Project { get; }
        public ISafetyComponentRepository SafetyComponent { get; }
        public ISafetyTextComponentRepository SafetyTextComponent { get; }
        public ISectionLayoutContentRepository SectionLayoutContent { get; }
        public IServicesComponentPhotoRepository ServicesComponentPhoto { get; }
        public IServicesComponentRepository ServicesComponent { get; }
        public ISiteConfigRepository SiteConfig { get; }
        public IHomeSliderComponentRepository HomeSliderComponent { get; }
        public ITeamComponentRepository TeamComponent { get; }
        public IValuesComponentRepository ValuesComponent { get; }
        public IVMVComponentRepository VMVComponent { get; }
        Task CommitAsync();
    }
}
