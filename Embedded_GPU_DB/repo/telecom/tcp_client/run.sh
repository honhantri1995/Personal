LD_LIBRARY_PATH=$LD_LIBRARY_PATH:./../../omnisci_db:/usr/local/lib

export LD_LIBRARY_PATH

# echo $LD_LIBRARY_PATH

cmd="tcp_client --cpu"
echo $cmd
./$cmd