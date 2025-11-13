using Binary_Tree_Level_Order_Traversal;

var task = new Solution();
var root = new TreeNode([3,9,20,null,null,15,7]);
var result = task.LevelOrder(root);

foreach (var level in result) {
	Console.WriteLine(string.Join(", ", level));
}
