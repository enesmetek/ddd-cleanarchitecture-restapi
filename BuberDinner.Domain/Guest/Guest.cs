﻿using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.Entities;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.MenuReview.ValueObjects;
using BuberDinner.Domain.User.ValueObjects;

namespace BuberDinner.Domain.Guest
{
    public sealed class Guest : AggregateRoot<GuestId>
    {
        private readonly List<DinnerId> _upcomingDinnerIds = [];
        private readonly List<DinnerId> _pastDinnerIds = [];
        private readonly List<DinnerId> _pendingDinnerIds = [];
        private readonly List<BillId> _billIds = [];
        private readonly List<MenuReviewId> _menuReviewIds = [];
        private readonly List<GuestRating> _ratings = [];

        public string FirstName { get; }
        public string LastName { get; }
        public Uri ProfileImage { get; }
        public UserId UserId { get; }

        public IReadOnlyList<DinnerId> UpcomingDinnerIds => _upcomingDinnerIds.AsReadOnly();
        public IReadOnlyList<DinnerId> PastDinnerIds => _pastDinnerIds.AsReadOnly();
        public IReadOnlyList<DinnerId> PendingDinnerIds => _pendingDinnerIds.AsReadOnly();
        public IReadOnlyList<BillId> BillIds => _billIds.AsReadOnly();
        public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
        public IReadOnlyList<GuestRating> Ratings => _ratings.AsReadOnly();

        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }

        private Guest(string firstName, string lastName, Uri profileImage, UserId userId, GuestRating? guestRating = null, GuestId? guestId = null)
            : base(guestId ?? GuestId.Create(userId))
        {
            FirstName = firstName;
            LastName = lastName;
            ProfileImage = profileImage;
            UserId = userId;
        }

        public static Guest Create(string firstName, string lastName, Uri profileImage, UserId userId)
        {
            return new Guest(firstName, lastName, profileImage, userId);
        }
    }
}
