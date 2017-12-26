
(function() {
  var $animate, $container, $message, $paragraph, MESSAGES, animate, initialise, scramble;

  MESSAGES = [];

  MESSAGES.push({
    delay: 0,
    text: "“Imagine a young Isaac Newton time-travelling from 1670s England to teach Harvard undergrads in 2017. After the time-jump, Newton still has an obsessive, paranoid personality, with Asperger’s syndrome, a bad stutter, unstable moods, and episodes of psychotic mania and depression."
  });

  MESSAGES.push({
    delay: 0,
    text: "But now he’s subject to Harvard’s speech codes that prohibit any “disrespect for the dignity of others”; any violations will get him in trouble with Harvard’s Inquisition (the ‘Office for Equity, Diversity, and Inclusion’). "
  });

  MESSAGES.push({
    delay:0,
    text: "Newton also wants to publish Philosophiæ Naturalis Principia Mathematica, to explain the laws of motion governing the universe. But his literary agent explains that he can’t get a decent book deal until Newton builds his ‘author platform’ to include at least 20k Twitter followers – without provoking any backlash for airing his eccentric views on ancient Greek alchemy, Biblical cryptography, fiat currency, Jewish mysticism, or how to predict the exact date of the Apocalypse. "
  });

  MESSAGES.push({
    delay: 0,
    text: "Newton wouldn’t last long as a ‘public intellectual’ in modern American culture. Sooner or later, he would say ‘offensive’ things that get reported to Harvard and that get picked up by mainstream media as moral-outrage clickbait. His eccentric, ornery awkwardness would lead to swift expulsion from academia, social media, and publishing."
  });



  MESSAGES.push({
    delay: 0,
    text: "Result?"
  });

  MESSAGES.push({
    delay: 0,
    text: "On the upside, he’d drive some traffic through Huffpost, Buzzfeed, and Jezebel, and people would have a fresh controversy to virtue-signal about on Facebook. On the downside, we wouldn’t have Newton’s Laws of Motion.”"
  });
	
  MESSAGES.push({
    delay: 1400,
    text: "― Geoffrey Miller"
  });

//	“Imagine a young Isaac Newton time-travelling from 1670s England to teach Harvard undergrads in 2017. After the time-jump, Newton still has an obsessive, paranoid personality, with Asperger’s syndrome, a bad stutter, unstable moods, and episodes of psychotic mania and depression. But now he’s subject to Harvard’s speech codes that prohibit any “disrespect for the dignity of others”; any violations will get him in trouble with Harvard’s Inquisition (the ‘Office for Equity, Diversity, and Inclusion’). Newton also wants to publish Philosophiæ Naturalis Principia Mathematica, to explain the laws of motion governing the universe. But his literary agent explains that he can’t get a decent book deal until Newton builds his ‘author platform’ to include at least 20k Twitter followers – without provoking any backlash for airing his eccentric views on ancient Greek alchemy, Biblical cryptography, fiat currency, Jewish mysticism, or how to predict the exact date of the Apocalypse.
//
//Newton wouldn’t last long as a ‘public intellectual’ in modern American culture. Sooner or later, he would say ‘offensive’ things that get reported to Harvard and that get picked up by mainstream media as moral-outrage clickbait. His eccentric, ornery awkwardness would lead to swift expulsion from academia, social media, and publishing. Result? On the upside, he’d drive some traffic through Huffpost, Buzzfeed, and Jezebel, and people would have a fresh controversy to virtue-signal about on Facebook. On the downside, we wouldn’t have Newton’s Laws of Motion.” 
//― Geoffrey Miller
	
  $container = $("#container");

  $message = $("#message");

  $animate = $("#animate");

  $paragraph = null;

  scramble = function(element, text, options) {
    var $element, addGlitch, character, defaults, ghostCharacter, ghostCharacters, ghostLength, ghostText, ghosts, glitchCharacter, glitchCharacters, glitchIndex, glitchLength, glitchProbability, glitchText, glitches, i, j, k, letter, object, order, output, parameters, ref, results, settings, shuffle, target, textCharacters, textLength, wrap;
    defaults = {
      probability: 0.3,
      glitches: '!<>-_\\/[]{}—=+*^?#alskefb.adsc;waef__',
      blank: '',
      duration: text.length * 40,
      ease: 'easeInOutQuad',
      delay: 0.0
    };
    $element = $(element);
    settings = $.extend(defaults, options);
    shuffle = function() {
      if (Math.random() < 0.5) {
        return 1;
      } else {
        return -1;
      }
    };
    wrap = function(text, classes) {
      return "<span class=\"" + classes + "\">" + text + "</span>";
    };
    glitchText = settings.glitches;
    glitchCharacters = glitchText.split('');
    glitchLength = glitchCharacters.length;
    glitchProbability = settings.probability;
    glitches = (function() {
      var j, len, results;
      results = [];
      for (j = 0, len = glitchCharacters.length; j < len; j++) {
        letter = glitchCharacters[j];
        results.push(wrap(letter, 'glitch'));
      }
      return results;
    })();
    ghostText = $element.text();
    ghostCharacters = ghostText.split('');
    ghostLength = ghostCharacters.length;
    ghosts = (function() {
      var j, len, results;
      results = [];
      for (j = 0, len = ghostCharacters.length; j < len; j++) {
        letter = ghostCharacters[j];
        results.push(wrap(letter, 'ghost'));
      }
      return results;
    })();
    textCharacters = text.split('');
    textLength = textCharacters.length;
    order = (function() {
      results = [];
      for (var j = 0; 0 <= textLength ? j < textLength : j > textLength; 0 <= textLength ? j++ : j--){ results.push(j); }
      return results;
    }).apply(this).sort(this.shuffle);
    output = [];
    for (i = k = 0, ref = textLength; 0 <= ref ? k < ref : k > ref; i = 0 <= ref ? ++k : --k) {
      glitchIndex = Math.floor(Math.random() * (glitchLength - 1));
      glitchCharacter = glitches[glitchIndex];
      ghostCharacter = ghosts[i] || settings.blank;
      addGlitch = Math.random() < glitchProbability;
      character = addGlitch ? glitchCharacter : ghostCharacter;
      output.push(character);
    }
    object = {
      value: 0
    };
    target = {
      value: 1
    };
    parameters = {
      duration: settings.duration,
      ease: settings.ease,
      step: function() {
        var index, l, progress, ref1;
        progress = Math.floor(object.value * (textLength - 1));
        for (i = l = 0, ref1 = progress; 0 <= ref1 ? l <= ref1 : l >= ref1; i = 0 <= ref1 ? ++l : --l) {
          index = order[i];
          output[index] = textCharacters[index];
        }
        return $element.html(output.join(''));
      },
      complete: function() {
        return $element.html(text);
      }
    };
    return $(object).delay(settings.delay).animate(target, parameters);
  };

  animate = function() {
    var data, element, index, j, len, options;
    for (index = j = 0, len = MESSAGES.length; j < len; index = ++j) {
      data = MESSAGES[index];
      element = $paragraph.get(index);
      element.innerText = '';
      options = {
        delay: data.delay
      };
      scramble(element, data.text, options);
    }
  };

  initialise = function() {
    var index, j, len, text;
    $animate.click(animate);
    for (index = j = 0, len = MESSAGES.length; j < len; index = ++j) {
      text = MESSAGES[index];
      $message.append("<p>");
    }
    $paragraph = $container.find("p");
    animate();
  };

  initialise();

}).call(this); 

//Typing text effect
