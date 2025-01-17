﻿// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE TO CONNECT THE WORLD
// ---------------------------------------------------------------

using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Taarafo.Core.Models.Posts;

namespace Taarafo.Core.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Post> Posts { get; set; }

        public async ValueTask<Post> InsertPostAsync(Post post)
        {
            using var broker = 
                new StorageBroker(this.configuration);
            
            EntityEntry<Post> postEntityEntry =
                await broker.Posts.AddAsync(post);

            await broker.SaveChangesAsync();

            return postEntityEntry.Entity;
        }

        public IQueryable<Post> SelectAllPosts()
        {
            using var broker = 
                new StorageBroker(this.configuration);

            return broker.Posts;
        }
    }
}
