using Exercises.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exercises.Models.Repositories
{
    public class StateRepository
    {
        private static List<State> _states;

        static StateRepository()
        {
            // sample data
            _states = new List<State>
            {
                new State { StateAbbreviation="kY", StateName="KeNtUcKy" },
                new State { StateAbbreviation="Mn", StateName="mInNeSoTa" },
                new State { StateAbbreviation="oH", StateName="OhIo" },
            };
        }

        public static IEnumerable<State> GetAll()
        {
            List<State> distinct = _states.Distinct().GroupBy(s => s.StateAbbreviation).Select(g => g.First()).ToList();

            return distinct;
        }

        public static State Get(string stateAbbreviation)
        {
            return _states.FirstOrDefault(c => c.StateAbbreviation == stateAbbreviation);
        }

        public static void Add(State state)
        {
            
            _states.Add(state);
        }

        public static void Edit(State state)
        {
            var selectedState = _states.FirstOrDefault(c => c.StateAbbreviation == state.StateAbbreviation);

            selectedState.StateName = state.StateName;
            selectedState.StateAbbreviation = state.StateAbbreviation;
        }

        public static void Delete(string stateAbbreviation)
        {
            _states.RemoveAll(c => c.StateAbbreviation == stateAbbreviation);
        }
    }
}