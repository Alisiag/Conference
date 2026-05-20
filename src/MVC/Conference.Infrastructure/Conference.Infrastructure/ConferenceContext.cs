using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ConferenceMVC.Domain.Entities;

namespace ConferenceMVC.Infrastucture;

public partial class ConferenceContext : DbContext
{
    public ConferenceContext()
    {
    }

    public ConferenceContext(DbContextOptions<ConferenceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Conference> Conferences { get; set; }

    public virtual DbSet<ContactPerson> ContactPeople { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<Participant> Participants { get; set; }

    public virtual DbSet<Partner> Partners { get; set; }

    public virtual DbSet<PricingPeriod> PricingPeriods { get; set; }

    public virtual DbSet<Session> Sessions { get; set; }

    public virtual DbSet<Speaker> Speakers { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Conference;Username=postgres;Password=1234;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("companies_pkey");

            entity.ToTable("companies");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Conference>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("conferences_pkey");

            entity.ToTable("conferences");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
        });

        modelBuilder.Entity<ContactPerson>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("contact_person_pkey");

            entity.ToTable("contact_person");

            entity.HasIndex(e => e.InvoiceId, "contact_person_invoice_id_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasColumnType("character varying")
                .HasColumnName("email");
            entity.Property(e => e.InvoiceId).HasColumnName("invoice_id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Surname)
                .HasColumnType("character varying")
                .HasColumnName("surname");

            entity.HasOne(d => d.Invoice).WithOne(p => p.ContactPerson)
                .HasForeignKey<ContactPerson>(d => d.InvoiceId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("invoice_contact");
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("invoices_pkey");

            entity.ToTable("invoices");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Status)
                .HasColumnName("status");
            entity.Property(e => e.TicketId).HasColumnName("ticket_id");
            entity.Property(e => e.TotalAmount).HasColumnName("total_amount");

            entity.HasOne(d => d.Ticket).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.TicketId)
                .HasConstraintName("invoice_ticket");
        });

        modelBuilder.Entity<Participant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("participants_pkey");

            entity.ToTable("participants");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.ConferenceId).HasColumnName("conference_id");
            entity.Property(e => e.Email)
                .HasColumnType("character varying")
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasColumnType("character varying")
                .HasColumnName("password");
            entity.Property(e => e.Surname)
                .HasColumnType("character varying")
                .HasColumnName("surname");

            entity.HasOne(d => d.Company).WithMany(p => p.Participants)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("participant_works_at_company");
        });

        modelBuilder.Entity<Partner>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("partners_pkey");

            entity.ToTable("partners");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('companies_id_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.ConferenceId).HasColumnName("conference_id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.PartnershipLevel)
                .HasColumnName("partnership_level");

            entity.HasOne(d => d.Conference).WithMany(p => p.Partners)
                .HasForeignKey(d => d.ConferenceId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("conference_partners");
        });

        modelBuilder.Entity<PricingPeriod>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pricing_periods_pkey");

            entity.ToTable("pricing_periods");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ConferenceId).HasColumnName("conference_id");
            entity.Property(e => e.EndDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("end_date");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.StartDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("start_date");

            entity.HasOne(d => d.Conference).WithMany(p => p.PricingPeriods)
                .HasForeignKey(d => d.ConferenceId)
                .HasConstraintName("conference_pricing");
        });

        modelBuilder.Entity<Session>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sessions_pkey");

            entity.ToTable("sessions");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ConferenceId).HasColumnName("conference_id");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.EndsAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("ends_at");
            entity.Property(e => e.StartsAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("starts_at");
            entity.Property(e => e.Title)
                .HasColumnType("character varying")
                .HasColumnName("title");

            entity.HasOne(d => d.Conference).WithMany(p => p.Sessions)
                .HasForeignKey(d => d.ConferenceId)
                .HasConstraintName("conference_sessions");

            entity.HasMany(d => d.Speakers).WithMany(p => p.Sessions)
                .UsingEntity<Dictionary<string, object>>(
                    "SessionSpeaker",
                    r => r.HasOne<Speaker>().WithMany()
                        .HasForeignKey("SpeakerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("fk_speaker_of_session"),
                    l => l.HasOne<Session>().WithMany()
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("fk_session_of_speaker"),
                    j =>
                    {
                        j.HasKey("SessionId", "SpeakerId").HasName("pk_session_speakers");
                        j.ToTable("session_speakers");
                        j.IndexerProperty<int>("SessionId").HasColumnName("session_id");
                        j.IndexerProperty<int>("SpeakerId").HasColumnName("speaker_id");
                    });
        });

        modelBuilder.Entity<Speaker>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("speakers_pkey");

            entity.ToTable("speakers");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('participants_id_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.ConferenceId).HasColumnName("conference_id");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.Email)
                .HasColumnType("character varying")
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasColumnType("character varying")
                .HasColumnName("password");
            entity.Property(e => e.Surname)
                .HasColumnType("character varying")
                .HasColumnName("surname");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tickets_pkey");

            entity.ToTable("tickets");

            entity.HasIndex(e => e.ParticipantId, "tickets_participant_id_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Discount).HasColumnName("discount");
            entity.Property(e => e.ParticipantId).HasColumnName("participant_id");
            entity.Property(e => e.PeriodId).HasColumnName("period_id");
            entity.Property(e => e.Price).HasColumnName("price");

            entity.HasOne(d => d.Participant).WithOne(p => p.Ticket)
                .HasForeignKey<Ticket>(d => d.ParticipantId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("participant_ticket");

            entity.HasOne(d => d.Period).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.PeriodId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("ticket_pricing");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
