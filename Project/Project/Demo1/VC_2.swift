//
//  VC_2.swift
//  Demo1
//
//  Created by Vamsee K Kuppa on 2017-12-11.
//  Copyright © 2017 Vamsee K Kuppa. All rights reserved.
//

import UIKit

class VC_2: UIViewController {
    
   
   
    @IBOutlet weak var titleLabel: UILabel!
    
    @IBOutlet weak var descLabel: UITextView!
    
    
    @IBOutlet weak var MenuImage: UIImageView!
    override func viewDidLoad() {
        super.viewDidLoad()
        // Do any additional setup after loading the view, typically from a nib.
        
        titleLabel.text = MenuItem[myIndex]
        descLabel.text = ItemDesc[myIndex]
        MenuImage.image = UIImage(named: MenuItem[myIndex] + ".jpg")
        
        
    }
    
    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }
    
    
}
