<?php
	// Initialize the session 
	session_start(); 

	if(isset($_POST['order_btn'])) {
		order();
	}

	function order()
	{
		require("config.php");

		////////////////////////////////////////////////
		// Insert into table account_customer
		$fullname = $_POST['fullname'];
		$gender = $_POST['gender'];
		$phone = $_POST['phone'];
		$address = $_POST['address'];
		$email = $_POST['email'];
		
		$username = "";
		if (isset($_SESSION['username']) == false)
		{
			$query = "SELECT COUNT(username) AS a_num FROM account_customer";
			$result = $con->query($query);
			$row = $result->fetch_array();
			$a_num = $row['a_num'] + 1;
			$username = "user"."_".($a_num);
			$password = "user"."_".$a_num;
		
			$query = "INSERT INTO account_customer
					  VALUES ('".$username."', '".$password."', '".$fullname."', '".$gender."', ".$phone.", '".$address."', '".$email."')";
			$result = $con->query($query);
			if ($result == false) {
				echo "ERROR: Buy product failed!\n" . $con->error . "\nYour query: " . $query;
				return;
			}
		}
		else {
			$username = $_SESSION['username'];
		}

		////////////////////////////////////////////////
		// Insert into table product_orders
		$product_id = $_SESSION['product_id'];
		$total_price = $_SESSION['total_price'];
		$quantity = $_POST['quantity'];

		$query = "SELECT MAX(id) AS orId FROM product_orders";
		$result = $con->query($query);
		$row = $result->fetch_array();
		$orId = $row['orId'] + 1;

	
		$query = "INSERT INTO product_orders
				  VALUES(".$orId.", ".$product_id.", '".$username."', ".$quantity.", ".$total_price.")";
		$result = $con->query($query);
		if ($result == false) {
			echo "ERROR: Buy product failed!\n" . $con->error . "\nYour query: " . $query;
			return;
		}

		////////////////////////////////////////////////
		// Notify success message
		echo "Buy product successfully!";

		$con->close();
	}
?>
