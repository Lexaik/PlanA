using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlanA.Models;

namespace PlanA.ModelConfigurations;

public class SubprocessConfiguration: IEntityTypeConfiguration<Sub_process>
{
    public void Configure(EntityTypeBuilder<Sub_process> builder)
    {
        builder.ToTable("Sub_Processes");
        builder.HasKey(p => new { p.ProcessId, p.SubProcessId });
        
        builder.HasOne(i => i.Process)
            .WithMany(s => s.ItemSubProcesses)
            .HasForeignKey(i => i.ProcessId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}