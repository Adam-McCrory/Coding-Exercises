
function topWatchlistedMoviesAmongFriends(userId, movies, users) {

    var user = users.find(user => user.userId === userId);

    if (user){

        let friendsInWatchlist = (watchlist) => user.friends.includes(watchlist);
        let byFriendsInWatchlist = (movie) => movie.watchlist.some(friendsInWatchlist);
        let friendsInWatchlistCount = (movie) => movie.watchlist.filter(friendsInWatchlist).length;
        let sortByTitleAlphabetically = (movie1, movie2) => movie1.title.localeCompare(movie2.title);
        let topFour = (movies) => movies.slice(0,4);

        return topFour(movies.filter(byFriendsInWatchlist).sort((movie1, movie2) => {
            let firstFriendCount = friendsInWatchlistCount(movie1);
            let secondFriendCount = friendsInWatchlistCount(movie2);

            return firstFriendCount > secondFriendCount ? -1 :
                firstFriendCount < secondFriendCount ? 1 :
                sortByTitleAlphabetically(movie1, movie2)})
        ).map(movie => movie.title);
    }
    else {
        return [];
    }
};

const movies = [
    {
        "title": "The Shawshank Redemption",
        "duration": "PT142M",
        "actors": [ "Tim Robbins", "Morgan Freeman", "Bob Gunton" ],
        "ratings": [],
        "favorites": [66380, 7001, 9250, 34139],
        "watchlist": [15291, 51417, 62289, 6146, 71389, 93707]
      },
      {
        "title": "The Godfather",
        "duration": "PT175M",
        "actors": [ "Marlon Brando", "Al Pacino", "James Caan" ],
        "ratings": [],
        "favorites": [15291, 51417, 7001, 9250, 71389, 93707],
        "watchlist": [62289, 66380, 34139, 6146]
      },
      {
        "title": "The Dark Knight",
        "duration": "PT152M",
        "actors": [ "Christian Bale", "Heath Ledger", "Aaron Eckhart" ],
        "ratings": [],
        "favorites": [15291, 7001, 9250, 34139, 93707],
        "watchlist": [51417, 62289, 6146, 71389]
      },
      {
        "title": "Pulp Fiction",
        "duration": "PT154M",
        "actors": [ "John Travolta", "Uma Thurman", "Samuel L. Jackson" ],
        "ratings": [],
        "favorites": [15291, 51417, 62289, 66380, 71389, 93707],
        "watchlist": [7001, 9250, 34139, 6146]
      },
      {
        "title": "Schindler's List",
        "duration": "PT195M",
        "actors": [
          "Liam Neeson",
          "Ralph Fiennes",
          "Ben Kingsley"
        ],
        "ratings": [{"userId": 62289, "rating": 8},{"userId": 66380, "rating": 5},{"userId": 6146, "rating": 6},{"userId": 71389, "rating": 7}],
        "favorites": [62289, 66380, 6146, 71389],
        "watchlist": [15291, 51417, 7001, 9250, 93707]
      },
      {
        "title": "The Lord of the Rings: The Return of the King",
        "duration": "PT190M",
        "actors": [],
        "ratings": [{"userId": 62289, "rating": 8},{"userId": 66380, "rating": 5},{"userId": 6146, "rating": 6},{"userId": 71389, "rating": 7}],
        "favorites": [62289, 66380, 6146, 71389],
        "watchlist": [15291, 51417, 9250, 93707]
      }
];

const users = [
    {
        "userId": 15291,
        "email": "Constantin_Kuhlman15@yahoo.com",
        "friends": [7001, 51417, 62289]
    },
    {
        "userId": 7001,
        "email": "Keven6@gmail.com",
        "friends": [15291, 51417, 62289, 66380]
    },
    {
        "userId": 51417,
        "email": "Margaretta82@gmail.com",
        "friends": [15291, 7001, 9250]
    },
    {
        "userId": 62289,
        "email": "Marquise.Borer@hotmail.com",
        "friends": [15291, 7001]
    }
];

console.log(JSON.stringify(topWatchlistedMoviesAmongFriends(62289, movies, users), null, "  "));
