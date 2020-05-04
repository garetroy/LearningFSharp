module LowOverheadTypeDefinitions

open System

type Person = {FirstName:string; LastName:string; Dob:DateTime}
type Coord = {Lat:float; Long:float}

type TimePeriod = Hour | Day | Week | Year
type Temperature = C of int | F of int
type Appointment = OneTime of DateTime 
                    | Recurring of DateTime list

type PersonBody = {person:Person; bodyTemp:Temperature}

type StreetAddress = {Line1:string; Line2:string;}
type City = {City:string;}
type ZipCode = ZipCode of string
type State = State of string
type ZipAndState = {State:State; Zip:ZipCode}
type USAddress = {Street:StreetAddress; City:City; StateAndZip:ZipAndState}

type Email = Email of string
type CountryPrefix = Prefix of int
type Phone = {CoutnryPrefix:CountryPrefix; LocalNumber:string}

type CustomerContact = 
    {
        PersonalInfo: Person;
        Address: StreetAddress option;
        Email: Email option;
        Phone: Phone option;
    }

type CustomerAccountId = AccountId of int
type CustomerType = Prospect | Active | Inactive

[<CustomEquality; NoComparison>]
type CustomerAccount = 
    {
        CustomerInfo: CustomerContact; 
        AccountId: CustomerAccountId;
        CustomerType: CustomerType;
    }

    override this.Equals(other) = 
        match other with
        | :? CustomerAccount as otherCust -> (this.AccountId = otherCust.AccountId)
        | _ -> false

//[<EntryPoint>]
//let main argv =
//    0 // return an integer exit code
