using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanA.Models;

namespace PlanA.ModelConfigurations;

public class SubprocessConfiguration: IEntityTypeConfiguration<Sub_Process>
{
    public void Configure(EntityTypeBuilder<Sub_Process> builder)
    {
        builder.ToTable("Sub_Processes");
        builder.HasKey(p => new { p.ProcessId, p.SubProcessId });
        
        builder.HasOne(i => i.Process)
            .WithMany(s => s.SubProcesses)
            .HasForeignKey(i => i.ProcessId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}