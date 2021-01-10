<?php
	require("config.php");

	if (isset($_POST["submit_btn"]))
	{
		// Initialize the session 
		session_start(); 

		$query = "SELECT * FROM account_customer WHERE username='".$_POST['username']."' AND password='".$_POST['password']."'";
		$result = $con->query($query);

		if($result->num_rows  == 1) {
			$row = $result->fetch_assoc();
			$_SESSION['username'] = $row['username'];
			$_SESSION['fullname'] = $row['fullname']; 
			$_SESSION['gender'] = $row['gender']; 
			$_SESSION['phone'] = $row['phone']; 
			$_SESSION['address'] = $row['address']; 
			$_SESSION['email'] = $row['email']; 
			header('Location: index.php');
		} else {
			echo "Invalid username or password. Please input again!";
		}
	}
?>


<!DOCTYPE html>
<html>
	<head>
		<link rel="stylesheet" href="./css/form.css">
	</head>

	<body>
		<h1 style="margin-left: 20px; ">Log In</h1>

		<div class="form-container-2">
			<form action="" method="POST">
				<label for="username_id">Username *</label><br>
				<input type="text" id="username_id" name="username" required><br>

				<label for="password_id">Password *</label><br>
				<input type="password" id="password_id" name="password" required>

				<input type="submit" name="submit_btn" value="Login"/>
			</form>

			<div>
				<p>Don't have an account? Sign in <a href="signin.php">here</a> </p>
			</div>
		</div>

	</body>
	
</html>