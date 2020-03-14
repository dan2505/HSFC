#Import sys and math modules
import sys, math

#Define the resources & login arrays
resources = []
login = []

#Define the userLogin function.
def userLogin():
    #Give the user the inputs to login.
    print("✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖")
    print("✖✖ Please login using your login details! ✖✖")
    print("✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖")
    username = input("✖ Username > ")
    password = input("✖ Password > ")
    
    #Declare the found variable.
    found = "false"

    #Begin a loop to search the array.
    for i in range(0, len(login)):
        #Check if the username in the array equals the username input.
        if login[i][0] == username:
            #Check if the password in the array equals the password input.
            if login[i][1] == password:
                #As it equals it set the found variable to true.
                found = "true"
                #Break out of the array.
                break

    #Check if it's been found.
    if found == "true":
        #Log the user in.
        menu(username)
    else:
        #As it hasn't been found tell them it's incorrect.
        print("✖ ERROR: Incorrect details! Please try again.")
        #Send them the login function again.
        userLogin()

#Declare the add function.
def add():
    #Begin loop and end when needed.
    while True:
        #Give them the inputs to enter the data of the resource.
        print("✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖")
        print("✖✖ Please enter the information of the resource to be added! ✖✖")
        print("✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖")
        title = input("✖ Title > ")
        text = input("✖ Text > ")
        keywords = input("✖ Keywords > ")
        age = str(input("✖ Intended Reading Age > "))
        #Set the calculated variable to be the string of the calculated reading age from the calculate function.
        calculated = str(calculate(text))

        #Check if the input is a number using a pre-made function.
        if isInt(age):
            #As it is a number break out of the loop.
            break
        #As the age isn't a number we'll ask them to enter a valid one.
        else:
            print("✖ Please enter a valid intended reading age.")
            
    #Create temporary array to store the resource.
    tmpArray = []
    #Clear it so no previous data is remaining in the array.
    del tmpArray [:]
    #Append all the data to a temporary array.
    tmpArray.append(title)
    tmpArray.append(text)
    tmpArray.append(keywords)
    tmpArray.append(age)
    tmpArray.append(calculated)
    #Append the temporary array to the main resources array.
    resources.append(tmpArray)

    #Define the resources file.
    file = open("resources.txt", 'a')
    #Write the data to the resources file, seperating each part with a ";,".
    file.write(title + ";," + text + ";," + keywords + ";," + age + ";," + calculated + "\n")
    #Close the file as we're finished with it.
    file.close

    #Tell the user it's been successfully added.
    print("✖ Successfully added " + title + " to the resource program!")
    #Return the calculated reading age of the text.
    print("✖ The calculated reading age of the text is " + str(calculated))

#Declare the menu function.
def menu(username):
    #Start a loop.
    while True:
        #Welcome the user and print function.
        print("✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖")
        print("✖✖   Welcome to the Automated Reading Index program, " + username + "!  ✖✖")
        print("✖✖    Please choose what function you would like to use!    ✖✖")
        print("✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖")
        print("✖ 1 | Search")
        print("✖ 2 | Add")
        print("✖ 3 | Logout")
        #Give them an input for it.
        choice = input("✖ > ")

        #Check which choice they chose.
        if choice == "1":
            #Open the search function for the user.
            search(username)
        elif choice == "2":
            #Open the add function for the user.
            add()
        elif choice == "3":
            #As they've logged out send them the login function.
            userLogin()
        else:
            #It equals nothing so tell them it's wrong.
            print("✖ ERROR: Invalid selection!")

#Define the search function.            
def search(username):
    #Declare the arrays and clear them from previous times.
    tmpArray = []
    numbers = []
    del tmpArray [:]
    del numbers [:]

    #Start loop
    while True:
        #Print the options.
        print("✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖")
        print("✖✖   What would you like to search with?  ✖✖")
        print("✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖✖")
        print("✖ 1 | Keywords")
        print("✖ 2 | Calculated Reading Age")
        
        #Give them the choice
        number = input("✖ > ")
        #If they choose to search with keywords.
        if number == "1":
            #Give them the input to search for keywords.
            keywords = input("✖ What keywords should we search for, " + username + "? > ")
            #Loop through the array.
            for i in range(0, len(resources)):
                #Check if it equals the input.
                if keywords.upper() in resources[i][2].upper():
                    #Append it to the temporary array.
                    tmpArray.append(resources[i][0] + " - " + str(i))
                    #Add it to the numbers array.
                    numbers.append(i)
            break
        elif number == "2":
            #Give them the input to search for reading age.
            calculated = input("✖ What calculated reading age should we search for, " + username + "? > ")
            #Check if it's an integer
            if isInt(calculated):
                #Loop through the array.
                for i in range(0, len(resources)):
                    #Check if it equals the input.
                    if calculated.upper() == resources[i][4].upper():
                        #Append it to the temporary array.
                        tmpArray.append(resources[i][0] + " - " + str(i))
                        #Add it to the numbers array.
                        numbers.append(i)
                break
            else:
                #It isn't an integer to tell them it's invalid.
                print("✖ ERROR: Invalid selection!")
        else:
            #They haven't chosen a valid option so tell them it's invalid.
            print("✖ ERROR: Invalid selection!")

    #Check if the length of the tmpArray is less than or equal to zero.
    if (len(tmpArray) <= 0):
        #As it is less than or equal to zero then no resource can be found with those specifications.
        print("✖ Nothing was found for that specified resource!")
        #Send the user the search function.
        search(username)
    #As it's greater than zero then a resource has been found.
    else:
        #Begin a loop.
        while True:
            print("✖ Select the resource you would like:")
            print("✖ Title - Resource Number\n")
            #Loop through all the resources that meet the specification.
            for i in range(0, len(tmpArray)):
                #Send each of the resources, line by line.
                print(tmpArray[i])
            print("\n✖ Which resource would you like to access?")
            print("✖ Type exit to exit!")
            #Ask them what resource they would like to access.
            choice = input("✖ > ")

            #Check if the resource that they've chosen is a number.
            if isInt(str(choice)):
                choice = int(choice)
                #Check if it's greater than the amount of resources.
                if choice > len(resources):
                    #Print invalid selection.
                    print("✖ Invalid selection")
                #Else, check if it's a number that has a resource linked to it.
                elif choice in numbers:
                    #As it has, print the resource's data.
                    print("\n✖ Title > " + resources[choice][0])
                    print("✖ Text > " + resources[choice][1])
                    print("✖ Keywords > " + resources[choice][2])
                    print("✖ Intended Reading Age > " + resources[choice][3])
                    print("✖ Calculated Reading Age > " + resources[choice][4] + "\n")
                    print("✖ Press enter to continue")
                    #Allow them to choose when they're finished, and to view other menus.
                    input("✖ > ")
                #As it isn't a number with a resource linked to it, tell them it's invalid.
                else:
                    #Print invalid selection.
                    print("✖ ERROR: Invalid selection!")
            #Check if they want to exit it.
            elif choice.upper() == "EXIT":
                #Send them the menu function again.
                menu(username)
            #As it's not a valid function.
            else:
                #Print invalid selection.
                print("✖ ERROR: Invalid selection!")

#Declare the calculate function.              
def calculate(text):
    #Calculate the word count.
    words = len(text.split())
    #Calculate the sentence count.
    sentences = text.count(".") + text.count("!") + text.count("?")

    #Check if there is an end of a sentence otherwise just assume there's only one.
    if sentences <= 0:
        sentences = 1
    #Work out the ari.
    ari = math.ceil(4.71 * (len(text)/words) + 0.5 * (words/sentences) - 21.43)
    #Return it back to the request.
    return ari

#Declare the setupLogin function.              
def setupLogin():
    #Clear login array from previous use.
    del login [:]
    #Begin try/except.
    try:
        #Open the login file.
        file = open("login.txt", 'r')
    #If the program cannot open the file then it will throw an IOError (e.g. doesn't exist).
    except IOError:
        #As we couldn't get into the file we'll close it so nobody can access it.
        print("✖ ERROR: Login file does not exist!")
        print("✖ Closing program...")
        #Close the program as there's no login file.
        sys.exit()
        return
    #Define the tmpArray.
    tmpArray = []
    #Define the counter.
    i=0
    #Clear the tmpArray if it's got any data in.
    del tmpArray [:]
    #Loop through each of the lines in the file.
    for line in file:
        #Define tmpLine as line.
        tmpLine = line
        #Check if it isn't blank.
        if tmpLine != "":
            #Split the username/password with a comma.
            tmpArray = tmpLine.split(",")
            #Append the username/password to the login array.
            login.append([])
            #Loop through the array.
            for b in range(0, len(tmpArray)):
                #Remove the \n from the textfile.
                tmpArray[b] = tmpArray[b].strip('\n')
                #Append it to the array.
                login[i].append(tmpArray[b])
            #Add one to the counter.
            i = i + 1

def setupResources():
    #Clear resources array from previous use.
    del resources [:]
    #Begin try/except.
    try:
        #Open the resources file.
        file = open("resources.txt", 'r')
    #If the program cannot open the file then it will throw an IOError (e.g. doesn't exist).
    except IOError:
        #As we couldn't get into the file we'll close it so nobody can access it.
        print("✖ ERROR: Resources file does not exist!")
        print("✖ Closing program...")
        #Close the program as there's no resources file.
        sys.exit()
        return
    #Define the tmpArray.
    tmpArray = []
    #Define the counter.
    i=0
    #Clear the tmpArray if it's got any data in.
    del tmpArray [:]
    #Loop through each of the lines in the file.
    for line in file:
        #Define tmpLine as line.
        tmpLine = line
        #Check if it isn't blank.
        if tmpLine != "":
           #Split the username/password with ;,.
           tmpArray = tmpLine.split(";,")
           #Append the resources to the resources array.
           resources.append([])
            #Loop through the array.
           for b in range(0, len(tmpArray)):
               #Remove the \n from the textfile.
                tmpArray[b] = tmpArray[b].strip('\n')
                #Append it to the array.
                resources[i].append(tmpArray[b])
           #Add one to the counter.
           i = i + 1

#Define a function to check if a string is an integer.
def isInt(integer):
    try:
        #Check if it is an integer.
        int(integer)
        #As it hasn't thrown an error say it's an integer.
        return True
    #The program is throwing an error as it cannot convert it to an integer, meaning it isn't an integer.
    except ValueError:
        #As it has thrown an error say it's not an integer.
        return False

#Setup the login array by executing the setup function.   
setupLogin()
#Setup the resource array by executing the setup function. 
setupResources()

#Send the login menu.
userLogin()
