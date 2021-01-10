<?php
	require("../config.php");

	if (isset($_POST["submit_btn"]))
	{
		// Initialize the session 
		session_start(); 

		$query = "SELECT * FROM account_admin WHERE username='".$_POST['username']."' AND password='".$_POST['password']."'";
		$result = $con->query($query);
		
		if($result->num_rows  == 1) {
			$_SESSION['username'] = $_POST['username']; 
			$_SESSION['password'] = $_POST['password']; 
			header('Location: home.php');
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
		</div>

	</body>
	
</html>