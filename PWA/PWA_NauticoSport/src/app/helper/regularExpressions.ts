export class regularExpressions {

    constructor(){}

    private regExpList: Record<string, RegExp> = {
        "email": RegExp("^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$"),
        "numbersOnly": RegExp("^[0-9]*$"),
        "password": RegExp("(?=.*[A-Z])"), // The string must contain at least 1 uppercase alphabetical character
    }

    public getRegExp = (key: string) => {
        return this.regExpList[key]
    }
}