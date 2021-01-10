<?php
	// Global variables
	$all_customers = array();

	if (isset($_GET['action']) && $_GET['action'] == "edit") {
		$all_customers = getCustomerInfo();
	}

	if(isset($_POST['submit_btn']))
	{
		edit();
	} 

	function getCustomerInfo()
	{
		require("../config.php");

		$query = "SELECT * FROM account_customer WHERE username = '".$_GET['username']."'";
		$result = $con->query($query);
	
		if ($result == false) {
			echo "ERROR: Edit customer account failed:\n" . $con->error . "\nYour query: " . $query;
			$con->close();
			return "";
		}
	
		$row = $result->fetch_assoc();
		$con->close();

		return $row;
	}

	function edit()
	{
		require("../config.php");

		$fullname = $_POST['fullname'];
		$gender = $_POST['gender'];
		$phone = $_POST['phone'];
		$address = $_POST['address'];
		$email = $_POST['email'];

		$query = "UPDATE account_customer SET fullname = '".$fullname."', gender = '".$gender."', phone = ".$phone.", address = '".$address."', email = '".$email."' WHERE username = '".$_GET['username']."'";
		$result = $con->query($query);

		if ($result) {
			echo "Edit customer account successfully!";
		}
		else {
			echo "ERROR: Edit customer account failed!\n" . $con->error . "\nYour query: " . $query;
		}

		$con->close();
	}
?>

<!DOCTYPE html>
<html>

<head>
	<link rel="stylesheet" href="css/form.css">
	<link rel="stylesheet" href="css/btn.css">
</head>

<body>
	<?php
		require("side_nav.php");
	?>

	<div class="form-container">

		<form method="POST" >
		
			<div class="form-group">
				<label class="label" for="basicinput">username</label>
				<input class="form" type="text" name="username" value="<?php echo $all_customers['username']; ?>" disabled>
			</div>
		
			<div class="form-group">
				<label class="label" for="basicinput">Full name</label>
				<input class="form"  type="text" name="fullname" value="<?php echo $all_customers['fullname']; ?>">
			</div>
	
			<div class="form-group">
				<label class="label" for="basicinput">Gender</label>
				<input class="form" type="text" name="gender" value="<?php echo $all_customers['gender']; ?>">
			</div>
		
			<div class="form-group">
				<label class="label" for="basicinput">Phone</label>
				<input class="form" type="text" name="phone" value="<?php echo $all_customers['phone']; ?>">
			</div>
		
			<div class="form-group">
				<label class="label" for="basicinput">Address</label>
				<input class="form" type="text" name="address" value="<?php echo $all_customers['address']; ?>">
			</div>
		
			<div class="form-group">
				<label class="label" for="basicinput">Email</label>
				<input class="form" type="text" name="email" value="<?php echo $all_customers['email']; ?>">
			</div>
		
			<div class="form-group" onclick="edit_customer_account.php">
				<button class="submit_btn" type="submit" name="submit_btn">Edit Account</button>
			</div>

		</form>

	</div>


</body>

</html>