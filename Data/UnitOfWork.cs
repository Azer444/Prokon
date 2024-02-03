using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Core.Repositories;
using Data.Contexts;

namespace Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProkonContext db;

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
        public INavSubComponentRepository NavSubComponent { get;}
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
        public IServicesComponentRepository ServicesComponent { get; }
        public IServicesComponentPhotoRepository ServicesComponentPhoto { get; }
        public ISiteConfigRepository SiteConfig { get;}
        public IHomeSliderComponentRepository HomeSliderComponent { get; }
        public ITeamComponentRepository TeamComponent { get; }
        public IValuesComponentRepository ValuesComponent { get; }
        public IVMVComponentRepository VMVComponent { get; }

        public UnitOfWork(ProkonContext db,
            IAboutComponentRepository aboutComponentRepository,
            IAboutPhotoRepository aboutPhotoRepository,
            IAdminRepository adminRepository,
            ICareerComponentRepository careerComponentRepository, 
            ICareerAppContentRepository careerAppContentRepository,
            ICareerFormComponentRepository careerFormComponentRepository,
            IConfigurationRepository configurationRepository,
            IContactComponentRepository contactComponentRepository,
            IContactMessageRepository contactMessageRepository,
            IContentAccessComponentRepository contentAccessComponentRepository,
            ICountryRepository countryRepository,
            IEthicsComponentRepository ethicsComponentRepository,
            IEthicsFileComponentRepository ethicsFileComponentRepository,
            IEthicsHotlineFormComponentRepository  ethicsHotlineFormComponentRepository,
            IFooterPartnerRepository footerPartnerRepository,
            IGalleryComponentPhotoRepository galleryComponentPhotoRepository,
            IGalleryComponentRepository galleryComponentRepository,
            IGeneralApplyFileRepository generalApplyFileRepository,
            IGeneralApplyRepository generalApplyRepository,
            IGovernanceComponentRepository governanceComponentRepository,
            ILicenceRepository licenceRepository,
            IManagementRepository managementRepository,
            INavComponentRepository navComponentRepository,
            INavSubComponentRepository navSubComponentRepository,
            INavTitleComponentRepository navTitleComponentRepository,
            INewsRepository newsRepository,
            INoticeComponentRepository noticeComponentRepository,
            IOpportunityApplyFileRepository opportunityApplyFileRepository,
            IOpportunityApplyRepository opportunityApplyRepository,
            IOpportunityRepository opportunityRepository,
            IPageAccessComponentRepository pageAccessComponentRepository,
            IPageMainPhotoRepository pageMainPhotoRepository,
            IPartnerComponentRepository partnerComponentRepository,
            IPartnerRepository partnerRepository,
            IPrivacyComponentRepository privacyComponentRepository,
            IProjectPhotoRepository projectPhotoRepository,
            IProjectRepository projectRepository,
            ISafetyComponentRepository safetyComponentRepository,
            ISafetyTextComponentRepository safetyTextComponentRepository,
            ISectionLayoutContentRepository sectionLayoutContentRepository,
            IServicesComponentPhotoRepository servicesComponentPhotoRepository,
            IServicesComponentRepository servicesComponentRepository,
            ISiteConfigRepository siteConfigRepository,
            IHomeSliderComponentRepository homeSliderComponentRepository,
            ITeamComponentRepository teamComponentRepository,
            IValuesComponentRepository valuesComponentRepository,
            IVMVComponentRepository vmvComponentRepository)
        {
            this.db = db;
            AboutComponent = aboutComponentRepository;
            AboutPhoto = aboutPhotoRepository;
            Admin = adminRepository;
            CareerComponent = careerComponentRepository;
            CareerAppContent = careerAppContentRepository;
            CareerFormComponent = careerFormComponentRepository;
            Configuration = configurationRepository;
            ContactComponent = contactComponentRepository;
            ContactMessage = contactMessageRepository;
            ContentAccessComponent = contentAccessComponentRepository;
            Country = countryRepository;
            EthicsComponent = ethicsComponentRepository;
            EthicsFileComponent = ethicsFileComponentRepository;
            EthicsHotlineFormComponent = ethicsHotlineFormComponentRepository;
            FooterPartner = footerPartnerRepository;
            GalleryComponentPhoto = galleryComponentPhotoRepository;
            GalleryComponent = galleryComponentRepository;
            GeneralApplyFile = generalApplyFileRepository;
            GeneralApply = generalApplyRepository;
            GovernanceComponent = governanceComponentRepository;
            Licence = licenceRepository;
            Management = managementRepository;
            NavComponent = navComponentRepository;
            NavSubComponent = navSubComponentRepository;
            NavTitleComponent = navTitleComponentRepository;
            News = newsRepository;
            NoticeComponent = noticeComponentRepository;
            OpportunityApplyFile = opportunityApplyFileRepository;
            OpportunityApply = opportunityApplyRepository;
            Opportunity = opportunityRepository;
            PageAccessComponent = pageAccessComponentRepository;
            PageMainPhoto = pageMainPhotoRepository;
            PartnerComponent = partnerComponentRepository;
            Partner = partnerRepository;
            PrivacyComponent = privacyComponentRepository;
            ProjectPhoto = projectPhotoRepository;
            Project = projectRepository;
            SafetyComponent = safetyComponentRepository;
            SafetyTextComponent = safetyTextComponentRepository;
            SectionLayoutContent = sectionLayoutContentRepository;
            ServicesComponentPhoto = servicesComponentPhotoRepository;
            ServicesComponent = servicesComponentRepository;
            SiteConfig = siteConfigRepository;
            HomeSliderComponent = homeSliderComponentRepository;
            TeamComponent = teamComponentRepository;
            ValuesComponent = valuesComponentRepository;
            VMVComponent = vmvComponentRepository;
        }

        public async Task CommitAsync()
        {
            await db.SaveChangesAsync();
        }
    }
}
