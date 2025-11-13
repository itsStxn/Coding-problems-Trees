using Lowest_Common_Ancestor_of_a_Binary_Search_Tree;

var task = new Solution();
var root = new TreeNode([6,2,8,0,4,7,9,null,null,3,5]);
var result = task.LowestCommonAncestor(root, new(2), new(4));
Console.WriteLine(result);
