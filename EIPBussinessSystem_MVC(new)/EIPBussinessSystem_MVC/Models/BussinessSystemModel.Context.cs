﻿//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace EIPBussinessSystem_MVC.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BusinessDataBaseEntities : DbContext
    {
        public BusinessDataBaseEntities()
            : base("name=BusinessDataBaseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<ActivitiesChild> ActivitiesChilds { get; set; }
        public virtual DbSet<ActivitiesMain> ActivitiesMains { get; set; }
        public virtual DbSet<Approval> Approvals { get; set; }
        public virtual DbSet<ApprovalProcedure> ApprovalProcedures { get; set; }
        public virtual DbSet<ApprovalStatu> ApprovalStatus { get; set; }
        public virtual DbSet<BulletinBoard> BulletinBoards { get; set; }
        public virtual DbSet<CommentChild> CommentChilds { get; set; }
        public virtual DbSet<CommentGrandchild> CommentGrandchilds { get; set; }
        public virtual DbSet<CommentMain> CommentMains { get; set; }
        public virtual DbSet<CompanyVehicle> CompanyVehicles { get; set; }
        public virtual DbSet<CompanyVehicleHistory> CompanyVehicleHistories { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<EventCalendar> EventCalendars { get; set; }
        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Leave> Leaves { get; set; }
        public virtual DbSet<MeetingRoom> MeetingRooms { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Office> Offices { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Recipient> Recipients { get; set; }
        public virtual DbSet<Reply> Replies { get; set; }
        public virtual DbSet<ReportCategory> ReportCategories { get; set; }
        public virtual DbSet<ReportTimeSystem> ReportTimeSystems { get; set; }
        public virtual DbSet<RequisitionMain> RequisitionMains { get; set; }
        public virtual DbSet<RewardandPunishment> RewardandPunishments { get; set; }
        public virtual DbSet<Suggestion> Suggestions { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<MeetingRoomHistory> MeetingRoomHistories { get; set; }
        public virtual DbSet<SuggestionHistory> SuggestionHistories { get; set; }
        public virtual DbSet<SurveyMain> SurveyMains { get; set; }
        public virtual DbSet<EventCalendar> EventCalendars { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
    }
}
