# Sorting Shakespeare  
## [Git LFS is required if you want to download the shakespeare-complete-works.txt file along with the project](https://git-lfs.github.com/)  
Otherwise you should replace the path to your local shakespeare file inside of `program.cs` on line 17.  

This is my solution to the [Sorting Shakespeare project](https://datsoftlyngby.github.io/soft2020spring/resources/d34f80c6-01-miniproject-sorting-shakespeare.pdf).  

All the sorting methods are run inside of the `program.cs` file. For Selection and Insertion sort I used a sample data of 10.000 elements, as they are very slow for unsorted arrays of this size.  
The results of running `program.cs` yields the results below:  
```
Sorted 10.000 strings in 3.992 MS using Selection Sort. That is 2,51 words sorted per millisecond.
Sorted 10.000 strings in 2.328 MS using Insertion Sort. That is 4,30 words sorted per millisecond.
Sorted 900.703 strings in 1.969 MS using Merge Sort. That is 457,44 words sorted per millisecond.
Sorted 900.703 strings in 5.212 MS using Heap Sort. That is 172,81 words sorted per millisecond.
Sorted 900.703 strings in 191 MS using Trie. That is 4.715,72 words sorted per millisecond.

```
