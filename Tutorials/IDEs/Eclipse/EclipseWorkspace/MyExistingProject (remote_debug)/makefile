# Run 'make' or 'make all' to build executable file
# Run 'make clean' to remove all object files and executable files
# Run 'make depend' to use makedepend to automatically generate dependencies 
#      (dependencies are added to end of Makefile)

# Define the compiler to use ('gcc' if C, or 'g++' if C++)
CC = g++

# Define compiler flags
#   For example, '-Wall' enables all warnings, '-g' adds debug info
CFLAGS = -Wall -g -std=c++11

# Define directories containing header files other than /usr/include
#   The rule is appending '-I' before the directory name 
HEADERS = -I./

# Define directories containing libraries other than /usr/lib
#   The rule is appending '-L' before the directory name 
LFLAGS =

# Define names of libraries to link into executable:
#   The rule is appending '-l' before the lib name 
#   For example, to link in libraries mylib.so or mylib.a, use -lmylib (no extension)
LIBS = 

# Define the C source files
SRCS =  bill.cpp \
        csv.cpp \
        main.cpp \
        product.cpp

# Define the C object files 
#   This uses Suffix Replacement within a macro: $(name:oldstr=newstr)
#   For each word in 'name', replace 'oldstr' with 'newstr'
# Below we're replacing the suffix .c of all words in SRCS with the .o suffix
OBJS = $(SRCS:.cpp=.o)

# Define the executable file 
EXE = mycc

# Running 'make' will invoke the first target entry in the file 
# You can name this target entry anything, but "default" or "all" are the convention
all: $(EXE)
	echo "All source files have been compiled"

# Compiling: Create object files from source files
# Below we're using pre-defined macros:
#    '$^' is the list of names of the dependencies (.c files)
#    '$@' is the name of the target (.o file) 
.cpp.o:
	$(CC) $(CFLAGS) $(HEADERS) -c $^ -o $@

# Linking: Create the executable file from object files
$(EXE): $(OBJS) 
	$(CC) $(CFLAGS) $(HEADERS) $(OBJS) $(LFLAGS) $(LIBS) -o $(EXE)

# Running 'make clean' removes the executable file, all .o files and *~ backup files
clean:
	del *.o $(EXE).exe

# Running 'make depend' generates dependencies of C source files automatically
depend: $(SRCS)
	makedepend $(HEADERS) $^

# DO NOT DELETE THIS LINE -- make depend needs it
