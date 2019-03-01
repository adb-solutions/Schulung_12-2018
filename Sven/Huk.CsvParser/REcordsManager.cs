using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huk.CsvParser
{
    class RecordsManager
    {
        StateMachine currentState;
        private RecordsManager(StateMachine state) {
            currentState = state;
        }
        public static RecordsManager GetRecordsManager(StateMachine state) {

            return new RecordsManager(state);
           
        }
        public Page GetFirstPage() {
            Page page = new Page()
                {
                    FieldNames = currentState.FieldNames,
                    Records = currentState.Records.Count>=currentState.RowsPerPage?
                        currentState.Records.Take(currentState.RowsPerPage):
                        currentState.Records};
            currentState.CurrentPage = 1;
            return page;

        }
        public Page GetNextPage() {

            var diff = (currentState.Records.Count / currentState.RowsPerPage) - currentState.CurrentPage;
            var skip = currentState.RowsPerPage * currentState.CurrentPage;

            Page p = new Page()
            {
                FieldNames = currentState.FieldNames
            };

            if (diff >= 1)
            {
                p.Records = currentState.Records.Skip(skip).Take(currentState.RowsPerPage);
                currentState.CurrentPage += 1;
            }
            else if (diff > 0 && diff < 1)
            {
                var take = diff * currentState.RowsPerPage;
                p.Records = currentState.Records.Skip(skip).Take(take);
                currentState.CurrentPage += 1;
            }
            else
            {
                p = GetLastPage();
            }
            return p;

        }
        public Page GetPreviousPage() {

            if (currentState.CurrentPage == 1)
                return GetFirstPage();

            Page p = new Page()
            {
                FieldNames = currentState.FieldNames
            };

            var prevPageSkip = currentState.Records.Count-(currentState.RowsPerPage*(currentState.CurrentPage - 1));

            p.Records = currentState.Records.Skip(prevPageSkip).Take(currentState.RowsPerPage);

            return p;

        }
        public Page GetLastPage() {
            double diff = (currentState.Records.Count / currentState.RowsPerPage)+0d;
            int floor = (int)Math.Floor(diff);
            double dd = diff - floor;

            Page p = new Page()
            {
                FieldNames = currentState.FieldNames
            };

            if (dd == 0)
            {
                p.Records = currentState.Records.Skip(currentState.RowsPerPage * (floor - 1)).Take(currentState.RowsPerPage);
                currentState.CurrentPage = floor;
            }
            else {
                var take = (int)dd * currentState.RowsPerPage;
                p.Records = currentState.Records.Skip(currentState.RowsPerPage * floor).Take(take);
                currentState.CurrentPage = floor+1;
            }

            return p;
        }
    }
}
