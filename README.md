# Cards.Core

A .NET library for working with payment card data, including card type identification, Luhn validation, and card number generation.

---

## Features
- Identify card types based on their Primary Account Number (PAN).
- Validate card numbers using the Luhn algorithm.
- Generate random card numbers for various card types.

---

## Installation

This library targets **.NET 8**. Add the project to your solution or include it as a dependency in your project.

---

## Usage

### **BINRange Class**

#### Constructor Overloads:
- - **`BINRange()`** 
Initializes a new instance of the BINRange class with default values.

- **`BINRange(string id, Range[] ranges)`** 
Initializes a new instance of the BINRange class with the specified identifier and ranges.
- 
#### Properties:
- **`string Id`**  
  Returns the Identifier of the BIN range.

- **`Range[] Ranges`**  
  Numerical ranges for the BIN. Each range is represented as a `Range` object, which contains a start and end value.

#### Example:

```csharp
var binRange = new BINRange("Visa", new Range[] { new Range(4000, 4999) });
```

### **Card Class**
The `Card` class represents a payment card and provides methods to identify its type and validate its PAN.

#### Constructor Overloads:
- **`Card(string pan)`**  
  Creates a card instance using a given PAN.
  
- **`Card(CardType cardType)`**  
  Creates a card instance with a randomly generated PAN for the specified card type.

#### Properties:
- **`string Pan`**  
  Returns the PAN of the card.

- **`CardType CardType`**  
  Identifies the type of the card (e.g., Visa, MasterCard).

- **`bool LuhnCheck`**  
  Indicates whether the PAN passes the Luhn algorithm validation.

#### Example:

```csharp
var card = new Card(CardType.Visa); Console.WriteLine(card.Pan); // Output: Randomly generated Visa PAN
```


---

### **Generator Class**
The `Generator` class provides methods to generate random card numbers.

#### Methods:
- **`string CardNumber(CardType cardType)`**  
  Generates a random card number for the specified card type.

#### Example:

```csharp
var cardNumber = Generator.CardNumber(CardType.MasterCard); Console.WriteLine(cardNumber); // Output: Randomly generated MasterCard PAN
```


---

### **Identification Class**
The `Identification` class provides methods to determine the type of a card based on its PAN.

#### Methods:
- **`CardType WhatIs(string pan)`**  
  Determines the card type based on the PAN.

- **`BINRange InRange(BINRange[] ranges, string pan)`**  
  Determines the bin range a card is within.  

#### Example:

```csharp
var cardType = Identification.WhatIs("4111111111111111"); Console.WriteLine(cardType);
```

```csharp
BINRange result = Identification.InRange(new BINRange(CardType.Visa.ToString(), new Range[] { new Range(4000, 4999) }), "4111111111111111");
```

---

### **Luhn Class**
The `Luhn` class provides methods for validating and generating card numbers using the Luhn algorithm.

#### Methods:
- **`bool IsValid(string pan)`**  
  Validates a PAN using the Luhn algorithm.

- **`string GenerateCard(string[] prefixes, Range sizeRange, bool luhnRequired)`**  
  Generates a random card number with the specified prefixes, size range, and Luhn check digit.

#### Example:

```csharp
bool isValid = Luhn.IsValid("5428542566720672"); Console.WriteLine(isValid); // Output: True
```

---

## CardType Enum
The `CardType` enum represents various card types:
- `Unknown`
- `Visa`
- `MasterCard`
- `AmericanExpress`
- `JCB`
- `DinersClub`
- `ChinaUnionPay`
- `Discover`
- `Maestro`

---

## Testing
Unit tests are provided in the `Cards.Tests` project. Run the tests using your preferred test runner.

---

## License
This project is licensed under the MIT License.
