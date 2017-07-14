using System;
using System.Data.Entity;
using HQF.Tutorial.EntityFramework.Commons.DbContexts;
using HQF.Tutorial.EntityFramework.Commons.Entities;

namespace DbLinqFunctions
{
    public class TreeNodeDbInitializer:DropCreateDatabaseAlways<TreeNodeDbContext>
    {
        protected override void Seed(TreeNodeDbContext context)
        {
            base.Seed(context);

            context.TreeNodes.Add(new TreeNode() {Id = 1, ParentId = 0, CreateTime = DateTime.Parse("2017-01-01")});
            context.TreeNodes.Add(new TreeNode() {Id = 2, ParentId = 1, CreateTime = DateTime.Parse("2017-01-01")});
            context.TreeNodes.Add(new TreeNode() {Id = 3, ParentId = 1, CreateTime = DateTime.Parse("2017-01-01")});
            context.TreeNodes.Add(new TreeNode() {Id = 4, ParentId = 1, CreateTime = DateTime.Parse("2017-01-01")});
            context.TreeNodes.Add(new TreeNode() {Id = 5, ParentId = 1, CreateTime = DateTime.Parse("2017-01-01")});


            context.TreeNodes.Add(new TreeNode() { Id = 10, ParentId = 0, CreateTime = DateTime.Parse("2017-02-01") });
            context.TreeNodes.Add(new TreeNode() { Id = 12, ParentId = 10, CreateTime = DateTime.Parse("2017-02-01") });
            context.TreeNodes.Add(new TreeNode() { Id = 13, ParentId = 10, CreateTime = DateTime.Parse("2017-02-01") });
            context.TreeNodes.Add(new TreeNode() { Id = 14, ParentId = 10, CreateTime = DateTime.Parse("2017-02-03") });
            context.TreeNodes.Add(new TreeNode() { Id = 15, ParentId = 10, CreateTime = DateTime.Parse("2017-02-03") });


            context.SaveChanges();

        }
    }
}
