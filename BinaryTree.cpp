#include <iostream>
#include <string>
using namespace std;

enum CHILD { LEFT, RIGHT }; //is used to indicate insertion direction
template <class ElemType>
class BTNode {
public:
	BTNode <ElemType> *left;
	BTNode <ElemType> *right;
	ElemType data;
	BTNode() :left(NULL), right(NULL) {}
	BTNode(ElemType e) :left(NULL), right(NULL), data(e) {}
	bool operator==(const ElemType &e)
	{
		return e == data;
	}

};

template <class ElemType>
class BinaryTree {
private:
	BTNode<ElemType> *root;
public:
	BinaryTree() :root(NULL) {}
	void insert(ElemType parentKey, ElemType newNodeKey, enum CHILD leftORright) //insert function takes parent node of the node to be inserted as new node and aslo takes direction of insertion as left or right
	{
		cout << "\nInserting(" << newNodeKey << ")" << "as "<<leftORright<<" to " <<(parentKey)<<endl;
		BTNode<ElemType> *newNode = new BTNode<ElemType>(newNodeKey);
		BTNode<ElemType> *nodePtr = getInsertionNode(root, parentKey);//find the parent node this function returns NULL if there no such node 
		if (nodePtr == NULL)//make newNode as root and current root as indicated by leftORright
		{
			if (leftORright == LEFT) {
				newNode->left = root;
				root = newNode;
			}
			else if (leftORright == RIGHT) {
				newNode->right = root;
				root = newNode;
			}

		}
		else {
			if (leftORright == LEFT) {//insertion of newNode will be done as left child of parent
				newNode->left = nodePtr->left;
				nodePtr->left = newNode;
			}
			else if (leftORright == RIGHT) {
				newNode->right = nodePtr->right;
				nodePtr->right = newNode;
			}

		}
	}

	void inOrderTraversal() {
		inOrder(root);
	}
	void preOrderTraversal() {
		preOrder(root);
	}
	void postOrderTraversal() {
		postOrder(root);
	}
	void levelOrderTraversal() {
		levelOrder(root);
	}
private:
	void inOrder(BTNode<ElemType> *root) {
		if (root != NULL) {
			inOrder(root->left);
			cout << (root->data);
			inOrder(root->right);
		}
	}
	void preOrder(BTNode<ElemType>*root) {
		if (root != NULL) {
			cout << root->data;
			preOrder(root->left);
			preOrder(root->right);
		}
	}
	void postOrder(BTNode<ElemType>*root) {
		if (root != NULL) 
			return 0;
		postOrder(root->left);
		postOrder(root->right);
		cout << root->data;
	}
	BTNode <ElemType> *getInsertionNode(BTNode<ElemType> *r, ElemType key)
	{
		if (r != NULL)
		{
			if (r->data == key)
				return r;
			BTNode<ElemType> *leftSub;
			leftSub = getInsertionNode(r->left, key);
			if (leftSub != NULL)
				return leftSub;
			return getInsertionNode(r->right, key);

		}
		return r;
	}


private:
	int cntNode(BTNode <ElemType>*root) const {
		if (root == NULL) return 0;
		int cntleft = cntNode(root->left);
		int cntright = cntNode(root->right);
		if (root->data < 0){
			return 1 + cntleft + cntright;
	}
		return cntleft + cntright;
	}
	int height(BTNode<ElemType>*root) {
		if (root == NULL) return 0;
		int lh = height(r->left);
		int rh = height(r->right);
		if (lh > rh)
			return 1 + lh;
		return 1 + rh;
	}
	bool isMember(BTNode <ElemType> *root, ElemType key) {
		if (root == NULL)
			return false;
		if (key == root->data)
			return true;
		bool resultl = isMember(r->left, key);
		bool resultr = isMember(r->right, key);
		if (rl == true)
			return true;
		return isMember(r -> right, key);
	}
	int leaf(BTNode <ElemType> *root) {
		if (root == NULL) return 0;
		if (root->left == NULL)
			return 1;
			if(root->right == NULL)
			return 1;
		lcnt = leaf(root->left);
		rcnt = leaf(root->right);
		return lcnt + rcnt;
	}
	public:
		int numberOfNode() const {
			return cntNode(root);
		}
		int numberOfHeight()const {
			return height(root);
		}
		int numberOfLeaf()const {
			return leaf(root);
		}
		bool Member()const {
			return true;
		}
};

void main()
{

	BinaryTree <int> myTree;
	myTree.insert(9, 9, LEFT);
	myTree.insert(9, 4, LEFT);
	myTree.inOrderTraversal();
	myTree.preOrderTraversal();
	myTree.insert(9, 5, RIGHT);
	myTree.inOrderTraversal();
	myTree.preOrderTraversal();
	myTree.insert(4, 3, LEFT);
	myTree.insert(4, 7, RIGHT);
	myTree.inOrderTraversal();
	myTree.preOrderTraversal();

	myTree.numberOfNode();
	myTree.numberOfLeaf();
	myTree.numberOfHeight();
	myTree.Member();
}