This is a .net Core 5.0 API with open API specification

Sample Request:
{
  "cartItems": [
    {
      "unit": "A",
      "quantity": 5
    },
    {
      "unit": "B",
      "quantity": 5
    },
    {
      "unit": "C",
      "quantity": 1
    },
    {
      "unit": "D",
      "quantity": 1
    }
  ]
}

Sample Response:

{
  "cartItems": [
    {
      "unit": "A",
      "quantity": 5
    },
    {
      "unit": "B",
      "quantity": 5
    },
    {
      "unit": "C",
      "quantity": 1
    },
    {
      "unit": "D",
      "quantity": 1
    }
  ]
}
Execute
Clear
Responses
Curl

curl -X POST "https://localhost:44389/api/Promotions" -H  "accept: */*" -H  "Content-Type: application/json" -d "{\"cartItems\":[{\"unit\":\"A\",\"quantity\":5},{\"unit\":\"B\",\"quantity\":5},{\"unit\":\"C\",\"quantity\":1},{\"unit\":\"D\",\"quantity\":1}]}"
Request URL
https://localhost:44389/api/Promotions
Server response
Code	Details
200	
Response body
Download
{
  "cartItems": [
    {
      "unit": "A",
      "quantity": 5,
      "itemTotalPrice": 250,
      "itemOfferPrice": 230,
      "promoApplied": "Get 3 A for 130",
      "unitPrice": 50
    },
    {
      "unit": "B",
      "quantity": 5,
      "itemTotalPrice": 150,
      "itemOfferPrice": 120,
      "promoApplied": "Get 2 B for 45",
      "unitPrice": 30
    },
    {
      "unit": "C",
      "quantity": 1,
      "itemTotalPrice": 20,
      "itemOfferPrice": 0,
      "promoApplied": "Get C & D Product",
      "unitPrice": 20
    },
    {
      "unit": "D",
      "quantity": 1,
      "itemTotalPrice": 15,
      "itemOfferPrice": 30,
      "promoApplied": "Get C & D Product",
      "unitPrice": 15
    }
  ],
  "cartTotal": 380
}
