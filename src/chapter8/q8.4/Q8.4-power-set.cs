using System;
using System.Collections.Generic;

namespace Chapter8
{
    public static class Q8_4PowerSet
    {
        public static List<List<T>> get_subsets<T>(List<T> set)
        {
            if(set == null)
                throw new ArgumentNullException(paramName: $"{nameof(get_subsets)} - The {nameof(set)} must not be null");

            List<List<T>> all_subsets = null;
            all_subsets = build_subsets<T>(set, 0);

            return all_subsets;
        }

        private static List<List<T>> build_subsets<T>(List<T> set, int index) 
        {
            List<List<T>> all_subsets = new List<List<T>>();           

            if(set.Count == index){
                all_subsets.Add(new List<T>());
                return all_subsets;
            }

            all_subsets = build_subsets(set,index + 1);
            List<List<T>> add_subsets = new List<List<T>>(all_subsets);
            T ele = set[index];

            foreach (var subset in add_subsets)
            {
                List<T> new_subsets = new List<T>(subset);
                new_subsets.Add(ele);
                all_subsets.Add(new_subsets);
            }

            return all_subsets;
        }
    }
}
