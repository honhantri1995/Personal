<!------------------------PHP----------------------------->
<?php 
function get_new_product()
{
 require("config.php");
 $sql="SELECT*from product where New_Product='1'";
 $result=$con->query($sql);

 if($result->num_rows > 0){
	 $x=0;
	 while($row=$result->fetch_assoc()){
		if($x%3==0){echo '<tr>';}
echo '<td><a href="product.php?product_id='.$row['id'].'"><img src="'.$row['image'].'"width="250"/><figcaption>'.$row['name'].': '.$row['price'].'</figcaption></a></td>';
if($x%3==2){echo'</tr>';}$x++;
		}
	 }
 }

?>

<?php 
function get_best_seller()
{
 require("config.php");
 $sql="SELECT*from product where Best_Seller='1'";
 $result=$con->query($sql);

 if($result->num_rows > 0){
	 $x=0;
	 while($row=$result->fetch_assoc()){
		if($x%4==0){echo '<tr>';}
echo '<td><a href="product.php?product_id='.$row['id'].'"><img src="'.$row['image'].'"height="220"/><figcaption>'.$row['name'].': '.$row['price'].'</figcaption></a></td>';
if($x%4==3){echo'</tr>';}$x++;
		}
	 }
 }

?>
<?php 
function get_sales_product()
{
 require("config.php");
 $sql="SELECT*from product where Sales_Product='1'";
 $result=$con->query($sql);

 if($result->num_rows > 0){
	 $x=0;
	 while($row=$result->fetch_assoc()){
		if($x%3==0){echo '<tr>';}
echo '<td><a href="product.php?product_id='.$row['id'].'"><img src="'.$row['image'].'"height="220"/><figcaption>'.$row['name'].': '.$row['price'].'</figcaption></a></td>';
if($x%3==2){echo'</tr>';}$x++;
		}
	 }
 }

?>




<!------------------------------HTML------------------>
<!DOCTYPE html>
<html>

<head>
	<link rel="stylesheet" href="css/product_table.css">
</head>

<body>
	<?php
		require("top_nav.php");
	?>
<img src="images/logo.jpg" width="100%">

<h1 style="margin-left: 40%;font-family:sans-serif">NEW PRODUCT</h1>

<div>
<table align="center">
<?php get_new_product() ?>
</table>
</div>
<h1 style="margin-left: 40%;font-family:sans-serif">BEST SELLER</h1>
<div>
	<table align="center">
		<?php get_best_seller()?>
	</table >
</div>
<img src="images/s.jpg" alt=""width="100%s">
<div>
	<table align="center">
		<?php get_sales_product() ?>
	</table>
</div>
</body>

</html>




