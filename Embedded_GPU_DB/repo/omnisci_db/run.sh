DYN_LIBS=/usr/local/lib
EXE=omni

LD_LIBRARY_PATH=$DYN_LIBS
export LD_LIBRARY_PATH

# echo $LD_LIBRARY_PATH

./$EXE --gpu