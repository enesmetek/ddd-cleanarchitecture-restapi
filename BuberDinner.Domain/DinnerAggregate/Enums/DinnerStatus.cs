﻿using Ardalis.SmartEnum;

namespace BuberDinner.Domain.DinnerAggregate.Enums
{
    public class DinnerStatus(string name, int value) : SmartEnum<DinnerStatus>(name, value)
    {
        public static readonly DinnerStatus Upcoming = new(nameof(Upcoming), 1);
        public static readonly DinnerStatus InProgress = new(nameof(InProgress), 2);
        public static readonly DinnerStatus Ended = new(nameof(Ended), 3);
        public static readonly DinnerStatus Cancelled = new(nameof(Cancelled), 4);
    }
}
