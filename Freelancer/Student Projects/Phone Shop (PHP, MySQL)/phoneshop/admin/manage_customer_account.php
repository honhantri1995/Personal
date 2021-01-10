<?php
	if (isset($_GET['action']) && $_GET['action'] == "delete") {
		deleteAccount($_GET['username']);
	}

	function getAccounts()
	{
		require("../config.php");

		$query = "SELECT * FROM account_customer";
		$result = $con->query($query);

		if ($result == false) {
			echo "ERROR: Get customer accounts failed:\n" . $con->error;
			$con->close();
			return;
		}

		$all_rows = array();
		while ($row = $result->fetch_assoc()) {
			array_push($all_rows, $row);
		}

		$con->close();
		return $all_rows;
	}

	function deleteAccount($username)
	{
		require("../config.php");

		$query = "DELETE FROM account_customer WHERE username = '".$username."'";
		$result = $con->query($query);

		if ($result == false) {
			echo "ERROR: Delete account failed:\n" . $con->error;
		}

		$con->close();
	}

?>

<!DOCTYPE html>
<html>

<head>
	<link rel="stylesheet" href="css/table_gridview.css">
	<link rel="stylesheet" href="css/btn.css">
	<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
</head>

<body>
	<?php
		require("side_nav.php");
	?>

	<div class="table-gridview-container">
		<table class="table-gridview">
			<tr>
				<th>Username</th>
				<!-- <th>password</th> -->
				<th>Full Name</th>
				<th>Gender</th>
				<th>Phone</th>
				<th>Address</th>
				<th>Email</th>
				<th>Action</th>
			</tr>

<?php
				foreach ($accounts = getAccounts() as $acc) {
?>
					<tr>
						<td><?php echo $acc['username']; ?></td>
						<!-- <td><?php //echo $acc['password']; ?></td> -->
						<td><?php echo $acc['fullname']; ?></td>
						<td><?php echo $acc['gender']; ?></td>
						<td><?php echo $acc['phone']; ?></td>
						<td><?php echo $acc['address']; ?></td>
						<td><?php echo $acc['email']; ?></td>

						<td>
							<a href="edit_customer_account.php?username=<?php echo $acc['username']; ?>&action=edit" >
							<button class="btn" ><i class="fa fa-edit"> Edit</i></button>
							
							<a href="manage_customer_account.php?username=<?php echo $acc['username']; ?>&action=delete" >
							<button class="btn" ><i class="fa fa-trash"> Delete</i></button>
						</td>
					</tr>
<?php
				}
?>
		</table>
	</div>


</body>

</html>