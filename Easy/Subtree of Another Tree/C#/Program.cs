using Subtree_of_Another_Tree;

var task = new Solution();
var root = new TreeNode([3,4,5,1,2]);
var sub = new TreeNode([4,1,2]);

var result = task.IsSubtree(root, sub);
Console.WriteLine(result);
