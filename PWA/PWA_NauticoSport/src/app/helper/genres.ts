export enum Genres {
    male = 1,
    female = 2,
    other = 3,
}

// Generate a list of genres with the text and the value
export class GenresMapper {
    constructor() {}

    public static map = () => {
        let mappedItems: any[] = [];
        Object.keys(Genres).filter((item) => {
          if (isNaN(Number(item))) // filtering the enum list to get only the string without the numbers por example to get "female" , "male" , "other"
          {
            mappedItems.push({text: `inputs.genres.options.${item}`, value: Genres[item as keyof typeof Genres] }) //Create a path for the idiom resources in en.js / es.js
          }
        })
        return mappedItems;
      }
}
