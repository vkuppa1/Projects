//
//  ViewController.swift
//  Demo1
//
//  Created by Vamsee K Kuppa on 2017-09-25.
//  Copyright © 2017 Vamsee K Kuppa. All rights reserved.
//

import UIKit

class ViewController: UIViewController, UIPickerViewDelegate, UIPickerViewDataSource,UITableViewDataSource, UITableViewDelegate{
    
    var Fetchvar = 0;
    
    let list = ["Good", "Bad", "Ugly"]
    
    public func tableView(_ tableView: UITableView, numberOfRowsInSection section: Int) -> Int{return (list.count)}
    
    
    // Row display. Implementers should *always* try to reuse cells by setting each cell's reuseIdentifier and querying for available reusable cells with dequeueReusableCellWithIdentifier:
    // Cell gets various attributes set automatically based on table (separators) and data source (accessory views, editing controls)
    
    public func tableView(_ tableView: UITableView, cellForRowAt indexPath: IndexPath) -> UITableViewCell
    {
        let Cell = UITableViewCell(style: UITableViewCellStyle.default, reuseIdentifier: "Cell")
        Cell.textLabel?.text = list[indexPath.row]
        return(Cell)
    }

    override func viewDidLoad() {
        super.viewDidLoad()
        
        
        // Do any additional setup after loading the view, typically from a nib.
    }

    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }

    
 
   
    @IBOutlet weak var Labelt: UILabel!
    
    @IBAction func Select(_ sender: Any) {
        let row = Picker.selectedRow(inComponent: 0)
        let selected = movieNames[row]
        
        let title = "Welcome on \(selected)!!"
        let alert = UIAlertController(
            title: title,
            message: "Procced!",
            preferredStyle: .alert)
        let action = UIAlertAction(
            title: "OK",
            style: .default,
            handler: nil)
        alert.addAction(action)
        present(alert, animated: true, completion: nil)
        
        if(Fetchvar == 0)
        {
            Labelt.text = "Kurma Chapathi"
            TextView.text = "Kurma Chapathi is a tough bead with Dough and with some potato soup."
            
        }
        if(Fetchvar == 1)
            
        {
            Labelt.text = "Masala Dosa"
            TextView.text = "Indian Rice Pancake stuffed with Potato Curry and Sausage if requested"
        }
        if(Fetchvar == 2)
        {
            Labelt.text = "Bharadi Bairi"
          TextView.text = "A Typical Rice Mixture that is added with Spices and dry fruits"
         
        }
        if(Fetchvar == 3)
        {
            Labelt.text = "Biriyani Keema"
        
          TextView.text = "Biriyani Keema is made of flavored Rice and Some Chicken if requested"
        }
        
        if(Fetchvar == 4)
        {
            Labelt.text = "Maza Thamala"
            
          TextView.text = "A Chicken Nugget type seasoning especially made by Gordon Ramsay"
        
        }
        
        if(Fetchvar == 5)
        {
            Labelt.text = "Gongure Pachadi"
            
            TextView.text = "An Easier thamal made by tendered Leaves with some thiragamootha"
            
        }
        
    }
    
 
    
   
    
    
    
    @IBOutlet weak var TextView: UITextView!

    @IBOutlet weak var Picker: UIPickerView!
   
  
  
    
    
    
    
    
    
    private let movieNames = [
        "Sunday", "Tuesday", "Wednesday", "Thursday", "Friday" ,"Saturday"]
    func pickerView(_ pickerView: UIPickerView, titleForRow row: Int, forComponent component: Int) -> String? {
        Fetchvar = row;
        return movieNames[row]
        
    }
    func pickerView(_ pickerView: UIPickerView, numberOfRowsInComponent component: Int) -> Int {
        return movieNames.count
    }

    public func numberOfComponents(in pickerView: UIPickerView) -> Int{
        return 1
    }
}

