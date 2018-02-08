import UIKit

var MenuItem = ["IDLI", "DOSA", "PURI","PAROTA"]
var ItemDesc = ["IDLI are a type of savoury rice cake, popular as breakfast foods throughout India and neighbouring countries like Sri Lanka.", "Dosa is a type of pancake from the Indian subcontinent, made from a fermented batter. It is somewhat similar to a crepe in appearance. Its main ingredients are rice and black gram.", "an unleavened deep-fried South Asian cuisine, commonly consumed on the Indian subcontinent. It is eaten for breakfast or as a snack or light meal.","Parota is a layered flatbread made from maida flour, from the culinary tradition of southern India, especially in Kerala, Tamil Nadu and the neighboring country Sri Lanka."]
var myIndex = 0

class TableViewController: UITableViewController {
    
    // MARK: - Table view data source
    
    override func tableView(_ tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
        // #warning Incomplete implementation, return the number of rows
        return MenuItem.count
    }
    
    override func tableView(_ tableView: UITableView, cellForRowAt indexPath: IndexPath) -> UITableViewCell {
        let cell = tableView.dequeueReusableCell(withIdentifier: "cell", for: indexPath)
        
        cell.textLabel?.text = MenuItem[indexPath.row]
        
        
        return cell
    }
        override func tableView(_ tableView: UITableView, didSelectRowAt indexPath: IndexPath)
    {
        myIndex = indexPath.row
        performSegue(withIdentifier: "segue", sender: self) 
    }
     
    }

