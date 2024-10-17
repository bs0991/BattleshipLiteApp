using ClassLibrary.Classes;
using ClassLibrary.Models;
using System;
using System.Collections.Generic;


namespace ClassLibrary.Builders
{
    public class GridBuilder
    {
        private GridModel _grid = new GridModel();

        public GridBuilder AddNewGrid()
        {
            _grid.Grid = Grid.InitializeGrid();
            return this;
        }

        public GridBuilder AddGridSelections(List<string> gridSelections)
        {
            _grid.GridSelections = gridSelections;

            return this;
        }

        public GridBuilder AddHitTargets(List<string> hitTargets)
        {
            _grid.HitTargets = hitTargets;

            return this;
        }

        public GridBuilder AddMissedTargets(List<string> missedTargets)
        {
            _grid.MissedTargets = missedTargets;

            return this;
        }

        public GridBuilder AddAllTargetSelections()
        {
            List<string> allTargetSelections = new List<string>();
            allTargetSelections.AddRange(_grid.HitTargets);
            allTargetSelections.AddRange(_grid.MissedTargets);
            _grid.AllTargetSelections = allTargetSelections;

            return this;
        }

        public GridModel Build()
        {
            return _grid;
        }
    }
}
