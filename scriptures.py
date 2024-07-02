# python

def main():
    scriture_dict = {"Nephi 1:1": "I Nephi", "Genisis 1:1": "In the Beggining"}

    # while True:
    #     print(scriture_dict)
    #     sriputre_title = input("What verse or verse do you want to learn: ")
    #     if sriputre_title == "exit":
    #         break
    #     scripture = input("What is the scripture: ")
    #     scriture_dict[sriputre_title] = scripture
    
    genisis_vers_one = scriture_dict["Genisis 1:1"]
    nephi_one_one = scriture_dict["Nephi 1:1"]
    while True:
        print("Nephi 1:1")
        print("Genisis 1:1")
        user_input = input("What verse do you want to see: ")
        if user_input == "Nephi 1:1":
            print(nephi_one_one)
        elif user_input == "Genisis 1:1":
            print(genisis_vers_one)
        elif user_input == "exit":
            break
        else:
            print("ERROR: try again")


    # print("Created Dictionarey:")
    # print(scriture_dict)

main()