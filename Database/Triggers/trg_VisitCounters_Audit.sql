-- Trigger: trg_VisitCounters_Audit
-- Purpose: Automatically audit all updates to the VisitCounters table
-- Created: 2026-02-02
-- Description: When the TotalVisits count is updated, this trigger
--              automatically inserts a record into VisitCountersAudit
--              to maintain a complete audit trail of all visit changes.

CREATE TRIGGER [dbo].[trg_VisitCounters_Audit]
ON [dbo].[VisitCounters]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Insert audit record with previous and new values
    INSERT INTO [dbo].[VisitCountersAudit] 
        (PreviousVisitCount, NewVisitCount, UpdatedAt, Action)
    SELECT 
        d.TotalVisits AS PreviousVisitCount,
        i.TotalVisits AS NewVisitCount,
        GETUTCDATE() AS UpdatedAt,
        'Increment' AS Action
    FROM inserted i
    JOIN deleted d ON i.Id = d.Id;
END