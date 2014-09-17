using System;
using System.Linq;
using SchoenyAzureContactMgr.Models;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Collections.Generic;

namespace SchoenyAzureContactMgr.DAL
{
    public class InitializeCmDatabaseWithSeedData : DropCreateDatabaseIfModelChanges<CmDataContext>
    {
        protected override void Seed(CmDataContext context)
        {
            context.GameType.Add(new GameType
            {
                Name = "Mike",
                Description = "The Mike Game."
            }
            );

            context.GameType.Add(new GameType
            {
                Name = "Janet",
                Description = "The Janet Game."
            }
            );

        }
    }
}