<?php
	require("config.php");

	if (isset($_POST["signin_btn"]))
	{
		$username = $_POST['username'];
		$password = $_POST['password'];
		$fullname = $_POST['fullname'];
		$gender = $_POST['gender'];
		$phone = $_POST['phone'];
		$address = $_POST['address'];
		$email = $_POST['email'];

		$query = "SELECT * FROM account_customer WHERE username='".$username."'";
		$result = $con->query($query);

		if($result->num_rows > 0) {
			echo "Username already exists. Please select another one!";
		}
		else {
			$query = "INSERT INTO account_customer
					  VALUES ('".$username."', '".$password."', '".$fullname."', '".$gender."', ".$phone.", '".$address."', '".$email."')";
			$result = $con->query($query);
			if ($result == false) {
				echo "ERROR: Signin failed!\n" . $con->error . "\nYour query: " . $query;
				return;
			}
			header('Location: login.php');
		}
	}
?>

<!DOCTYPE html>
<html>
	<head>
		<link rel="stylesheet" href="./css/form.css">
	</head>

	<body>
		<h1 style="margin-left: 20px; ">Sign In</h1>

		<div class="form-container-2">
			<form action="" method="POST">
				<div class="form-group">
					<label class="label" for="basicinput">Username *</label>
					<input class="form" type="text" name="username" required>
				</div>
				
				<div class="form-group">
					<label class="label" for="basicinput">Password *</label>
					<input class="form" type="text" name="password" required>
				</div>

				<div class="form-group">
					<label class="label" for="basicinput">Full name *</label>
					<input class="form" type="text" name="fullname" required>
				</div>
				
				<div class="form-group">
					<label class="label" for="basicinput">Gender *</label>
					<select class="form" name="gender" required>
						<option value="Male">Male</option>
						<option value="Female">Female</option>
					</select>
				</div>
				
				<div class="form-group">
					<label class="label" for="basicinput">Phone *</label>
					<input class="form" type="text" name="phone" required>
				</div>
			
				<div class="form-group">
					<label class="label" for="basicinput">Address *</label>
					<textarea class="form" name="address" style="height: 100px" required></textarea>
				</div>

				<div class="form-group">
					<label class="label" for="basicinput">Email</label>
					<input class="form" type="text" name="email">
				</div>

				<div class="form-group" >
					<button class="submit_btn" type="submit" name="signin_btn">Sign-In</button>
				</div>
			</form>
		</div>

	</body>
	
</html>