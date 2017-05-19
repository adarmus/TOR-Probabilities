using System;
using System.Collections.Generic;
using System.Text;

namespace Probs
{
    class RollOutcome
    {
        public RollOutcome()
        {
            Status = RollOutcomeStatus.Fail;
        }

        public RollOutcome(RollOutcomeStatus status)
        {
            Status = status;
        }

        public bool IsAnySuccess => this.Status != RollOutcomeStatus.Fail;

        public RollOutcomeStatus Status { get; }
    }

    enum RollOutcomeStatus
    {
        Fail,
        OrdinarySuccess,
        GreatSuccess,
        ExtraordinarySuccess
    }
}
