﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sandbox.Game.Entities;
using Sandbox.Game.Entities.Cube;
using Sandbox.ModAPI;
using Torch.Commands;

namespace Essentials.Commands
{
    [Category("blocks")]
    public class BlocksModule : CommandModule
    {
        [Command("on type", "Turn on all blocks of the given type.")]
        public void OnType(string type)
        {
            var count = 0;
            foreach (var grid in MyEntities.GetEntities().OfType<MyCubeGrid>())
            {
                foreach (var block in grid.GetFatBlocks().OfType<MyFunctionalBlock>())
                {
                    var blockType = block.BlockDefinition.Id.TypeId.ToString().Substring(16);
                    if (block != null && string.Compare(type, blockType, StringComparison.InvariantCultureIgnoreCase) ==
                        0)
                    {
                        block.Enabled = true;
                        count++;
                    }
                }
            }

            Context.Respond($"Enabled {count} blocks of type {type}.");
        }

        [Command("on subtype", "Turn on all blocks of the given subtype.")]
        public void OnSubtype(string subtype)
        {
            var count = 0;
            foreach (var grid in MyEntities.GetEntities().OfType<MyCubeGrid>())
            {
                foreach (var block in grid.GetFatBlocks().OfType<MyFunctionalBlock>())
                {
                    var blockType = block.BlockDefinition.Id.SubtypeName;
                    if (block != null &&
                        string.Compare(subtype, blockType, StringComparison.InvariantCultureIgnoreCase) == 0)
                    {
                        block.Enabled = true;
                        count++;
                    }
                }
            }

            Context.Respond($"Enabled {count} blocks of subtype {subtype}.");
        }

        [Command("off type", "Turn off all blocks of the given type.")]
        public void OffType(string type)
        {
            var count = 0;
            foreach (var grid in MyEntities.GetEntities().OfType<MyCubeGrid>())
            {
                foreach (var block in grid.GetFatBlocks().OfType<MyFunctionalBlock>())
                {
                    var blockType = block.BlockDefinition.Id.TypeId.ToString().Substring(16);
                    if (block != null && string.Compare(type, blockType, StringComparison.InvariantCultureIgnoreCase) ==
                        0)
                    {
                        block.Enabled = false;
                        count++;
                    }
                }
            }


            Context.Respond($"Disabled {count} blocks of type {type}.");
        }

        [Command("remove subtype", "Turn off all blocks of the given subtype.")]
        public void RemoveSubtype(string subtype)
        {
            var toRemove = new List<MySlimBlock>();
            foreach (var grid in MyEntities.GetEntities().OfType<MyCubeGrid>())
            {
                foreach (var block in grid.GetBlocks())
                {
                    var blockType = block.BlockDefinition.Id.SubtypeName;
                    if (string.Compare(subtype, blockType, StringComparison.InvariantCultureIgnoreCase) == 0)
                        toRemove.Add(block);
                }
            }

            foreach (var x in toRemove)
                x.CubeGrid.RazeBlock(x.Position);
            Context.Respond($"Removed {toRemove.Count} blocks of subtype {subtype}.");
        }

        [Command("remove type", "Turn off all blocks of the given type.")]
        public void RemoveType(string type)
        {
            var toRemove = new List<MySlimBlock>();
            foreach (var grid in MyEntities.GetEntities().OfType<MyCubeGrid>())
            {
                foreach (var block in grid.GetBlocks())
                {
                    var blockType = block.BlockDefinition.Id.TypeId.ToString().Substring(16);
                    if (string.Compare(type, blockType, StringComparison.InvariantCultureIgnoreCase) == 0)
                        toRemove.Add(block);
                }
            }

            foreach (var x in toRemove)
                x.CubeGrid.RazeBlock(x.Position);
            Context.Respond($"Removed {toRemove.Count} blocks of type {type}.");
        }

        [Command("off subtype", "Turn off all blocks of the given subtype.")]
        public void OffSubtype(string subtype)
        {
            var count = 0;
            foreach (var grid in MyEntities.GetEntities().OfType<MyCubeGrid>())
            {
                foreach (var block in grid.GetFatBlocks().OfType<MyFunctionalBlock>())
                {
                    var blockType = block.BlockDefinition.Id.SubtypeName;
                    if (block != null &&
                        string.Compare(subtype, blockType, StringComparison.InvariantCultureIgnoreCase) == 0)
                    {
                        block.Enabled = false;
                        count++;
                    }
                }
            }


            Context.Respond($"Disabled {count} blocks of subtype {subtype}.");
        }
    }
}