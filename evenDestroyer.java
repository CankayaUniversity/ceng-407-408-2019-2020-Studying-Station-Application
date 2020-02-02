7) (10p)Consider binary tree that has integer data value in its nodes.
Write a recursive function that will accept binary tree as its argument.
The function should decrement the data value every node that has even value by one.

public void evenDestroyer(){
	evenDestroyer(root);
}
private void evenDestroyer(Node root){
	if(root==null){
		return ;
	}
	if (root.left!=null || root.right!=null){
		if(root.data%2!=0){
			evenDestroyer(root.left);
			evenDestroyer(root.right);
		}
		else {
			root.data=root.data-1;
			evenDestroyer(root.left);
			evenDestroyer(root.right);
			}
	}
	else if(root.data%2==0){
		root.data=root.data-1;
	}
	
}