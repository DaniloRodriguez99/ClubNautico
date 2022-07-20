export enum DocumentTypes {
    dni = 1,
    passport = 2,
}

export class DocumentTypesMapper {
    constructor() {}

    
    // Generate a list of document types with the text and the value
    public static map = () => {
        let mappedItems: any[] = [];
        Object.keys(DocumentTypes).filter((item) => {
          if (isNaN(Number(item))) // filtering the enum list to get only the string without the numbers por example to get "female" , "male" , "other"
          {
            mappedItems.push({text: `inputs.documentTypes.options.${item}`, value: DocumentTypes[item as keyof typeof DocumentTypes]}) //Create a path for the idiom resources in en.js / es.js
          }
        })
        return mappedItems;
      }
}