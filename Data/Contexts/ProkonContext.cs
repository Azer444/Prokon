using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Contexts
{
    public class ProkonContext : IdentityDbContext
    {
        public ProkonContext(DbContextOptions<ProkonContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "2c5e174e-3b0e-446f-86af-483d56fd7210", Name = "Manager", NormalizedName = "Manager".ToUpper() });
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "3d6z593d-5f8e-392d-10zk-132c92mz9482", Name = "Admin", NormalizedName = "Admin".ToUpper() });
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "48jw043d-53ke-d830-dk21-394fje93jd92", Name = "HR", NormalizedName = "HR".ToUpper() });


            var hasher = new PasswordHasher<IdentityUser>();

            builder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                    UserName = "prokon_manager",
                    NormalizedUserName = "prokon_manager".ToUpper(),
                    PasswordHash = hasher.HashPassword(null, "prokonmanager321"),
                }
            );

            builder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    Id = "3ekc3dr5-3kds-3910-93js-49d4kw024kd9",
                    UserName = "prokon_hr",
                    NormalizedUserName = "prokon_hr".ToUpper(),
                    PasswordHash = hasher.HashPassword(null, "prokonhr321"),
                }
            );

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                    UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
                }
            );

            builder.Entity<IdentityUserRole<string>>().HasData(
              new IdentityUserRole<string>
              {
                  RoleId = "48jw043d-53ke-d830-dk21-394fje93jd92",
                  UserId = "3ekc3dr5-3kds-3910-93js-49d4kw024kd9"
              }
          );
        }

        public DbSet<AboutComponent> AboutComponents { get; set; }
        public DbSet<AboutPhoto> AboutPhotos { get; set; }
        public DbSet<CareerComponent> CareerComponents { get; set; }
        public DbSet<CareerAppContent> CareerAppContent { get; set; }
        public DbSet<CareerFormComponent> CareerFormComponent { get; set; }
        public DbSet<ContactComponent> ContactComponents { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }
        public DbSet<PartnerComponent> ClientPartnerComponents { get; set; }
        public DbSet<ContentAccessComponent> ContentAccessComponents { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<EthicsComponent> EthicsComponents { get; set; }
        public DbSet<EthicsFileComponent> EthicsFileComponents { get; set; }
        public DbSet<EthicsHotlineFormComponent> EthicsHotlineFormComponent { get; set; }
        public DbSet<FooterPartner> FooterPartners { get; set; }
        public DbSet<HomeSliderComponent> HomeSliderComponents { get; set; }
        public DbSet<GalleryComponent> GalleryComponents { get; set; }
        public DbSet<GalleryComponentPhoto> GalleryComponentPhotos { get; set; }
        public DbSet<GeneralApply> GeneralApplies { get; set; }
        public DbSet<GeneralApplyFile> GeneralApplyFiles { get; set; }
        public DbSet<GovernanceComponent> GovernanceComponents { get; set; }
        public DbSet<Licence> Licences { get; set; }
        public DbSet<Management> Management { get; set; }
        public DbSet<NavComponent> NavComponents { get; set; }
        public DbSet<NavSubComponent> NavSubComponents { get; set; }
        public DbSet<NavTitleComponent> NavTitleComponents { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<NoticeComponent> NoticeComponent { get; set; }
        public DbSet<Opportunity> Opportunities { get; set; }
        public DbSet<OpportunityApply> OpportunityApplies { get; set; }
        public DbSet<OpportunityApplyFile> OpportunityApplyFiles { get; set; }
        public DbSet<SectionLayoutContent> SectionLayoutContents { get; set; }
        public DbSet<SiteConfig> SiteConfig { get; set; }
        public DbSet<PageAccessComponent> PageAccessComponents { get; set; }
        public DbSet<PageMainPhoto> PagesMainPhotos { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<PrivacyComponent> PrivacyComponent { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectPhoto> ProjectPhotos { get; set; }
        public DbSet<SafetyComponent> SafetyComponents { get; set; }
        public DbSet<SafetyTextComponent> SafetyTextComponent { get; set; }
        public DbSet<ServicesComponent> ServicesComponents { get; set; }
        public DbSet<ServicesComponentPhoto> ServicesComponentPhotos { get; set; }
        public DbSet<TeamComponent> TeamComponents { get; set; }
        public DbSet<ValuesComponent> ValuesComponents { get; set; }
        public DbSet<VMVComponent> VMVComponents { get; set; }
    }
}
