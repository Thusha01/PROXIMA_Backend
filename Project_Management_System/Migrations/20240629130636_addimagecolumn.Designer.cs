﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project_Management_System.Data;

#nullable disable

namespace Project_Management_System.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240629130636_addimagecolumn")]
    partial class addimagecolumn
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Project_Management_System.Models.Admin", b =>
                {
                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.HasKey("AdminId");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("Project_Management_System.Models.Budget", b =>
                {
                    b.Property<int>("BudgetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BudgetId"));

                    b.Property<double>("ConnectionCost")
                        .HasColumnType("float");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<double>("DeveloperCost")
                        .HasColumnType("float");

                    b.Property<double>("HardwareCost")
                        .HasColumnType("float");

                    b.Property<double>("LicenseCost")
                        .HasColumnType("float");

                    b.Property<string>("Objectives")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("OtherExpenses")
                        .HasColumnType("float");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<double>("SelectionprocessCost")
                        .HasColumnType("float");

                    b.Property<double>("ServersCost")
                        .HasColumnType("float");

                    b.Property<double>("TotalCost")
                        .HasColumnType("float");

                    b.HasKey("BudgetId");

                    b.HasIndex("ProjectId")
                        .IsUnique();

                    b.ToTable("Budgets");
                });

            modelBuilder.Entity("Project_Management_System.Models.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientId"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NIC")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilPhotoLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TotalPayment")
                        .HasColumnType("float");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClientId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Project_Management_System.Models.Developer", b =>
                {
                    b.Property<int>("DeveloperId")
                        .HasColumnType("int");

                    b.Property<int>("FinanceReceiptId")
                        .HasColumnType("int");

                    b.Property<int>("TotalDeveloperWorkingHours")
                        .HasColumnType("int");

                    b.HasKey("DeveloperId");

                    b.ToTable("Developers");
                });

            modelBuilder.Entity("Project_Management_System.Models.DeveloperFinancialRecipt", b =>
                {
                    b.Property<int>("ReceiptId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReceiptId"));

                    b.Property<int>("CurrentMonthWorkingHours")
                        .HasColumnType("int");

                    b.Property<int>("DeveloperId")
                        .HasColumnType("int");

                    b.Property<double>("HourlyRate")
                        .HasColumnType("float");

                    b.Property<int>("PreviousMonthWorkingHours")
                        .HasColumnType("int");

                    b.HasKey("ReceiptId");

                    b.ToTable("DeveloperFinancialRecipts");
                });

            modelBuilder.Entity("Project_Management_System.Models.DeveloperProject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DeveloperId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DeveloperId");

                    b.HasIndex("ProjectId");

                    b.ToTable("DeveloperProjects");
                });

            modelBuilder.Entity("Project_Management_System.Models.DeveloperRate", b =>
                {
                    b.Property<int>("Rateid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Rateid"));

                    b.Property<double>("CurrentRate")
                        .HasColumnType("float");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Rateid");

                    b.ToTable("DeveloperRates");
                });

            modelBuilder.Entity("Project_Management_System.Models.FileResource", b =>
                {
                    b.Property<int>("FileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FileId"));

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LocalStoragePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int?>("TaskId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("FileId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("TaskId");

                    b.ToTable("FileResources");
                });

            modelBuilder.Entity("Project_Management_System.Models.Invoice", b =>
                {
                    b.Property<int>("InvoiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InvoiceId"));

                    b.Property<double>("ExpenseAmount")
                        .HasColumnType("float");

                    b.Property<string>("ExpenseType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("GeneratedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("InvoiceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PaymentAmount")
                        .HasColumnType("float");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("InvoiceId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("Project_Management_System.Models.JobRole", b =>
                {
                    b.Property<int>("JobRoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JobRoleId"));

                    b.Property<string>("JobRoleType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("JobRoleId");

                    b.ToTable("JobRoles");
                });

            modelBuilder.Entity("Project_Management_System.Models.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentId"));

                    b.Property<int>("DeveloperId")
                        .HasColumnType("int");

                    b.Property<int>("Month")
                        .HasColumnType("int");

                    b.Property<int>("MonthlyWorkedHours")
                        .HasColumnType("int");

                    b.Property<double>("TotalMonthPayment")
                        .HasColumnType("float");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("PaymentId");

                    b.HasIndex("DeveloperId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Project_Management_System.Models.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectId"));

                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.Property<string>("BudgetEstimation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int?>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("Objectives")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("P_DueDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("P_StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProjectDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjectManagerId")
                        .HasColumnType("int");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeamName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Technologies")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TimeLine")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalProjectCompletedHours")
                        .HasColumnType("int");

                    b.Property<int>("TotalProjectHours")
                        .HasColumnType("int");

                    b.Property<int>("TotalProjectRemainingHours")
                        .HasColumnType("int");

                    b.HasKey("ProjectId");

                    b.HasIndex("AdminId");

                    b.HasIndex("ClientId");

                    b.HasIndex("ProjectManagerId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Project_Management_System.Models.ProjectManager", b =>
                {
                    b.Property<int>("ProjectManagerId")
                        .HasColumnType("int");

                    b.HasKey("ProjectManagerId");

                    b.ToTable("ProjectManagers");
                });

            modelBuilder.Entity("Project_Management_System.Models.RefreshToken", b =>
                {
                    b.Property<int>("TokenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TokenId"));

                    b.Property<DateTime?>("RefreshTokenExpiryTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("TokenId");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("Project_Management_System.Models.Task", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaskId"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Dependancy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DeveloperId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TaskCompleteTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("TaskDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaskName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TaskPauseTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TaskStartTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("TaskStatus")
                        .HasColumnType("int");

                    b.Property<string>("Technology")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TimeDuration")
                        .HasColumnType("int");

                    b.Property<int>("TotalTaskTimeDuration")
                        .HasColumnType("int");

                    b.HasKey("TaskId");

                    b.HasIndex("DeveloperId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("Project_Management_System.Models.TaskTime", b =>
                {
                    b.Property<int>("TaskTimeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaskTimeId"));

                    b.Property<int>("DeveloperId")
                        .HasColumnType("int");

                    b.Property<int>("TaskId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TaskTimeCompleteTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TaskTimeStartTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("TotalTimeTaskTimeDuration")
                        .HasColumnType("int");

                    b.HasKey("TaskTimeId");

                    b.HasIndex("DeveloperId");

                    b.HasIndex("TaskId");

                    b.ToTable("TaskTimes");
                });

            modelBuilder.Entity("Project_Management_System.Models.Transaction", b =>
                {
                    b.Property<int>("TransacId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransacId"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Expence")
                        .HasColumnType("float");

                    b.Property<double>("Income")
                        .HasColumnType("float");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("TransacId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Project_Management_System.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("JobRoleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("JoinDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastLoginDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NIC")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfileImageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("JobRoleId");

                    b.HasIndex("UserCategoryId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Project_Management_System.Models.UserCategory", b =>
                {
                    b.Property<int>("UserCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserCategoryId"));

                    b.Property<string>("UserCategoryType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserCategoryId");

                    b.ToTable("UsersCategories");
                });

            modelBuilder.Entity("Project_Management_System.Models.ViewInvoice", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<int>("InvoiceId")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.ToTable("ViewInvoices");
                });

            modelBuilder.Entity("Project_Management_System.Models.ViewReport", b =>
                {
                    b.Property<int>("BudgetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BudgetId"));

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("BudgetId");

                    b.ToTable("ViewReports");
                });

            modelBuilder.Entity("Project_Management_System.Models.ViewResource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FileId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ViewResources");
                });

            modelBuilder.Entity("Project_Management_System.Models.Admin", b =>
                {
                    b.HasOne("Project_Management_System.Models.User", "User")
                        .WithOne("Admin")
                        .HasForeignKey("Project_Management_System.Models.Admin", "AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Project_Management_System.Models.Budget", b =>
                {
                    b.HasOne("Project_Management_System.Models.Project", "Project")
                        .WithOne("Budget")
                        .HasForeignKey("Project_Management_System.Models.Budget", "ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Project_Management_System.Models.Developer", b =>
                {
                    b.HasOne("Project_Management_System.Models.User", "User")
                        .WithOne("Developer")
                        .HasForeignKey("Project_Management_System.Models.Developer", "DeveloperId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Project_Management_System.Models.DeveloperProject", b =>
                {
                    b.HasOne("Project_Management_System.Models.Developer", "Developer")
                        .WithMany("DeveloperProjects")
                        .HasForeignKey("DeveloperId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project_Management_System.Models.Project", "Project")
                        .WithMany("DeveloperProjects")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Developer");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Project_Management_System.Models.FileResource", b =>
                {
                    b.HasOne("Project_Management_System.Models.Project", "Project")
                        .WithMany("FileResources")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project_Management_System.Models.Task", "Task")
                        .WithMany("FileResources")
                        .HasForeignKey("TaskId");

                    b.Navigation("Project");

                    b.Navigation("Task");
                });

            modelBuilder.Entity("Project_Management_System.Models.Payment", b =>
                {
                    b.HasOne("Project_Management_System.Models.Developer", "Developer")
                        .WithMany("Payment")
                        .HasForeignKey("DeveloperId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Developer");
                });

            modelBuilder.Entity("Project_Management_System.Models.Project", b =>
                {
                    b.HasOne("Project_Management_System.Models.Admin", "Admin")
                        .WithMany("Projects")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project_Management_System.Models.Client", "Client")
                        .WithMany("Projects")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project_Management_System.Models.ProjectManager", "ProjectManager")
                        .WithMany("Projects")
                        .HasForeignKey("ProjectManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");

                    b.Navigation("Client");

                    b.Navigation("ProjectManager");
                });

            modelBuilder.Entity("Project_Management_System.Models.ProjectManager", b =>
                {
                    b.HasOne("Project_Management_System.Models.User", "User")
                        .WithOne("ProjectManager")
                        .HasForeignKey("Project_Management_System.Models.ProjectManager", "ProjectManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Project_Management_System.Models.RefreshToken", b =>
                {
                    b.HasOne("Project_Management_System.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Project_Management_System.Models.Task", b =>
                {
                    b.HasOne("Project_Management_System.Models.Developer", "Developer")
                        .WithMany("Tasks")
                        .HasForeignKey("DeveloperId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project_Management_System.Models.Project", "Project")
                        .WithMany("Tasks")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Developer");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Project_Management_System.Models.TaskTime", b =>
                {
                    b.HasOne("Project_Management_System.Models.Developer", "Developer")
                        .WithMany("TaskTimes")
                        .HasForeignKey("DeveloperId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project_Management_System.Models.Task", "Task")
                        .WithMany("TaskTimes")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Developer");

                    b.Navigation("Task");
                });

            modelBuilder.Entity("Project_Management_System.Models.Transaction", b =>
                {
                    b.HasOne("Project_Management_System.Models.Project", "Project")
                        .WithMany("Transactions")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Project_Management_System.Models.User", b =>
                {
                    b.HasOne("Project_Management_System.Models.JobRole", "JobRole")
                        .WithMany()
                        .HasForeignKey("JobRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project_Management_System.Models.UserCategory", "UserCategory")
                        .WithMany()
                        .HasForeignKey("UserCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JobRole");

                    b.Navigation("UserCategory");
                });

            modelBuilder.Entity("Project_Management_System.Models.Admin", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("Project_Management_System.Models.Client", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("Project_Management_System.Models.Developer", b =>
                {
                    b.Navigation("DeveloperProjects");

                    b.Navigation("Payment");

                    b.Navigation("TaskTimes");

                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("Project_Management_System.Models.Project", b =>
                {
                    b.Navigation("Budget")
                        .IsRequired();

                    b.Navigation("DeveloperProjects");

                    b.Navigation("FileResources");

                    b.Navigation("Tasks");

                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("Project_Management_System.Models.ProjectManager", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("Project_Management_System.Models.Task", b =>
                {
                    b.Navigation("FileResources");

                    b.Navigation("TaskTimes");
                });

            modelBuilder.Entity("Project_Management_System.Models.User", b =>
                {
                    b.Navigation("Admin")
                        .IsRequired();

                    b.Navigation("Developer")
                        .IsRequired();

                    b.Navigation("ProjectManager")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
