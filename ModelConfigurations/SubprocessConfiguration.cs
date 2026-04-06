using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanA.Models;

namespace PlanA.ModelConfigurations;

public class SubprocessConfiguration: IEntityTypeConfiguration<SubProcess>
{
    public void Configure(EntityTypeBuilder<SubProcess> builder)
    {
        builder.ToTable("Sub_Processes");
        builder.HasKey(p => new { p.ProcessId, p.SubProcessId });
        
        builder.HasOne(i => i.Process)
            .WithMany(s => s.ItemSubProcesses)
            .HasForeignKey(i => i.ProcessId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}