class Food{
    Food(code, count){
        this.Count = count;
        this.Code = code;
    }
   get Code(){
       return code;
   }
   set Code(){
        this.code = value;
   }
   get Count(){
       return count;
   }
   set Count(){
       this.count = value
   }
}
class IRestourante {
    restouranteName();
    order(list, foodList)
 }
class FastFoodRestourante extends IRestourante {
     order(list,foodList){
        orderString = "[";
        for(let i = 0 ;i<foodList.Count; i++){
            orderString += "[" + foodList[i].Code + ", " + foodList[i].Count + "]";
            if (i < foodList.Count - 1) orderString += ", ";
        }
        orderString += "]";
        return orderString;
    }
    restouranteName(){
        return "McDonalds";
    }
}
class JapanRestourante extends IRestourante {
    order(list, foodList){
        codeList = "[";
        countList = "[";
        for (let i = 0; i < foodList.Count; i++){
            codeList += foodList[i].Code;
                countList += foodList[i].Count;
                if (i < foodList.Count - 1) 
                { 
                    countList += ", ";
                    codeList += ", ";
                }
        } 
        codeList += "]";
        countList += "]";
        return codeList + ", " + countList;
    }
    restouranteName(){
        return "Sushi";
    }
}
class TraditionalRestourante extends IRestourante {
    order(list, foodList){
        orderString = "[";
        for(let i = 0; i < foodList.Count; i++){
            for (let j = 0; j < foodList[i].Count; j++){
                orderString += foodList[i].Code + ", ";
            }
        }
        orderString = orderString.Substring(0, orderString.length - 2) + "]";
        return orderString;
    }
    restouranteName(){
        return "Traditional Ukrainian foods";
    }
}
class OrderFactory {
    selectRestourante(foodType) {
        switch(foodType){
            case "a":
                selectedRestourante = new FastFoodRestourante();
                return;
            case "b":
                selectedRestourante = new JapanRestourante();
                return;
            case "c":
                selectedRestourante = new TraditionalRestourante();
            default:
                selectedRestourante = null;
            break;
            
        }
    }
    order(list,foodList){
        if(selectedRestourante == null){
            console.log("No selected restourante");
            return;
        }
        console.log(selectedRestourante.restouranteName());
        console.log(selectedRestourante.order(foodList));
    }
}

class App {
    OrderFactory = new OrderFactory();
}


