# python

def main():
    scriture_dict = {}

    while True:
        sriputre_title = input("What verse or verse do you want to learn: ")
        if sriputre_title == "exit":
            break
        scripture = input("What is the scripture: ")
        scriture_dict[sriputre_title] = scripture
    
    print("Created Dictionarey:")
    print(scriture_dict)

main()